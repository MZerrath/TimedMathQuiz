using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimedMathQuiz
{
    public partial class Form1 : Form
    {
        int secondsCounter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BeginQuiz();
        }

        private void BeginQuiz()
        {
            GenerateRandomAdditions();
            StartTheTime();
        }

        void GenerateRandomAdditions()
        {
            Random numbers = new Random();
            int digit = numbers.Next(10) + 1;

            label1.Text = (numbers.Next(10) + 1).ToString();
            label3.Text = (numbers.Next(10) + 1).ToString();
            label5.Text = (numbers.Next(10) + 1).ToString();
            label7.Text = (numbers.Next(10) + 1).ToString();
            label9.Text = (numbers.Next(10) + 1).ToString();
            label11.Text = (numbers.Next(10) + 1).ToString();
        }

        bool CheckAnswers()
        {
            int answer1 = Convert.ToInt32(label1.Text) + Convert.ToInt32(label3.Text);
            int answer2 = Convert.ToInt32(label5.Text) + Convert.ToInt32(label7.Text);
            int answer3 = Convert.ToInt32(label9.Text) + Convert.ToInt32(label11.Text);

            int userAnswer1 = 0;
            int userAnswer2 = 0;
            int userAnswer3 = 0;
            int.TryParse(txtAnswer1.Text, out userAnswer1);
            int.TryParse(txtAnswer2.Text, out userAnswer2);
            int.TryParse(txtAnswer3.Text, out userAnswer3);

            if (answer1 == userAnswer1 && answer2 == userAnswer2 && answer3 == userAnswer3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void txtAnswer1_TextChanged(object sender, EventArgs e)
        {
            if (CheckAnswers())
            {
                FinishQuiz();
            }
        }

        private void txtAnswer2_TextChanged(object sender, EventArgs e)
        {
            if (CheckAnswers())
            {
                FinishQuiz();
            }
        }

        private void txtAnswer3_TextChanged(object sender, EventArgs e)
        {
            if (CheckAnswers())
            {
                FinishQuiz();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsCounter += 1;
            lblTimer.Text = secondsCounter.ToString() + " seconds";

        }

        void StartTheTime()
        {
            timer1.Start();
            secondsCounter = 0;
            lblTimer.Text = secondsCounter.ToString() + " seconds";
        }

        private void FinishQuiz()
        {
            timer1.Stop();
            lblMessage.Text = "Your time: " + lblTimer.Text;
            lblMessage.Visible = true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtAnswer1.Text = "";
            txtAnswer2.Text = "";
            txtAnswer3.Text = "";
            txtAnswer1.Focus();
            lblMessage.Visible = false;

            BeginQuiz();
        }
    }
}
