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
        private string m_WordToGuess = "";
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
            groupBox2.Controls["label" + m_CurrentLabelLetter].Text = buttonText;
            m_CurrentLabelLetter++;
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

                button27.Visible = false;
                button28.Visible = false;
            }
        }
    }
}
