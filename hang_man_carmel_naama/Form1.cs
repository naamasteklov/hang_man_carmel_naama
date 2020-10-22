using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hang_man_carmel_naama
{
    public partial class Form1 : Form
    {
        private int m_CurrentLabelLetter = 1;
        public Form1()
        {
            InitializeComponent();
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
            switch (m_CurrentLabelLetter)
            {
                case 1:
                    {
                        label1.Text = buttonText;
                        break;
                    }
                case 2:
                    {
                        label2.Text = buttonText;
                        break;
                    }

                case 3:
                    {
                        label3.Text = buttonText;
                        break;
                    }
                case 4:
                    {
                        label4.Text = buttonText;
                        break;
                    }
                case 5:
                    {
                        label5.Text = buttonText;
                        break;
                    }



            }
            m_CurrentLabelLetter++;
        }
    }
}
