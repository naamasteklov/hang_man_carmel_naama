using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using hang_man_carmel_naama.Properties;

namespace hang_man_carmel_naama
{

    public partial class Form1 : Form
    {
        private int m_CurrentLabelLetter = 1;
        private string m_WordToGuess = "";
        private Image[] m_Images = new Image[11]; //המערך של התמונות
        private int m_CountError = 0; // סופר טעויות
        private bool m_IsFirstPlayer = true;// אם זה תורו של השחקן הראשון
        private int countL = 0;// סופר את התווים שנמצאו
        private int countempty = 0;// סופר את התאים הריקים שעברנו עליהם (ברמז(
        private int rndd;// מקום רנדומלי לרמז


        public void SetImagesArray()
        {
            //מציבה תמונות בכל תאי מערך התמונות  
            m_Images[0] = Resources.p0;
            m_Images[1] = Resources.p1;
            m_Images[2] = Resources.p2;
            m_Images[3] = Resources.p3;
            m_Images[4] = Resources.p4;
            m_Images[5] = Resources.p5;
            m_Images[6] = Resources.p6;
            m_Images[7] = Resources.p7;
            m_Images[8] = Resources.p8;
            m_Images[9] = Resources.p9;
            m_Images[10] = Resources.p10;
        }

        public Form1()
        {
            InitializeComponent();
            SetImagesArray();
            button29.Visible = false; // מעלים את הכפתור של הרמז בהתחלה
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        private void groupBox2_MouseCaptureChanged(object sender, EventArgs e)
        {

        }


        private void button_Letter_Click(object sender, EventArgs e)
        {
            string buttonText = (sender as Button).Text;
            if (m_IsFirstPlayer)
            {
                groupBox2.Controls["label" + m_CurrentLabelLetter].Text = buttonText;
                m_CurrentLabelLetter++;
            }

            //השחקן השני

            else
            {

                //צדק

                if (m_WordToGuess.Contains(buttonText))
                {

                    //הצגת האות בכל המקומות המתאימים

                    for (int i = 0; i < m_WordToGuess.Length; i++)
                        if (m_WordToGuess[i].ToString() == buttonText)
                        {
                            groupBox2.Controls["label" + (i + 1)].Text = buttonText;
                            countL++;//תוסיף למספר התווים שנמצאו
                        }

                    if (countL>4)//אם יש את כל חמשת האותיות
                    {
                        MessageBox.Show("player 2 won! :)");//השחקן השני ניצח
                    }


                }

                //השחקן טעה

                else
                {

                    //הצגת תמונת שגיאה
                    
                    m_CountError++;
                    if (m_CountError < 10)// אם מספר הטעויות קטן מעשר
                    {
                        pictureBox1.Image = m_Images[m_CountError];
                    }

                    else //אם הוא לא קטן מעשר
                    {
                        pictureBox1.Image = m_Images[10];//תציג תמונה של הפסד
                    
                        MessageBox.Show("player 2 lost... :(");// השחקן השני ניצח

                    }
                }

            // חסימת האפשרות ללחיצה על כפתור האות הנוכחית שוב

            (sender as Button).Enabled = false;
            }
        
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (m_CurrentLabelLetter > 1)
            {
                groupBox2.Controls["label" + (m_CurrentLabelLetter - 1)].Text = "_";
                m_CurrentLabelLetter--;
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            Label curLabel;
            for (int i = 1; i <= 5; i++)
            {
                curLabel = groupBox2.Controls["label" + i] as Label;
                m_WordToGuess += curLabel.Text;
                curLabel.Text = "_";

                
            }
            button27.Visible = false;
            button28.Visible = false;
            button29.Visible = true;
            m_IsFirstPlayer = false;
        }

        private void button29_Click(object sender, EventArgs e)
        { 
            Random rnd = new Random();
            rndd = rnd.Next(m_WordToGuess.Length-countL-1);// מגריל מקום בין המקומות הריקים
            for (int i = 0; i < m_WordToGuess.Length; i++)// סורק את כל התאים 
            {
                if (groupBox2.Controls["label" + (i + 1)].Text == "_")//אם התא ריק
                {
                    countempty++;//תוסיף למקומות הריקים
                }

                if (rndd == (countempty-1))//אם מספר הריקים שווה למספר המוגרל
                {
                    groupBox2.Controls["label" + (i + 1)].Text = m_WordToGuess[i].ToString();// תכניס את האות הנכונה בתו הנכון
                    countL++;// תוסיף למספר התווים שנמצאו
                    if(countL>4)// אם יש את כל חמשת האותיות
                    {
                        MessageBox.Show("player 2 won! :)");// השחקן השני ניצח
                    }
                    button29.Visible = false;//תעלים את הכפתור של הרמז (רק רמז אחד)
                    break;// צא מהלולאה

                }
            }
            

        }
    }
}
