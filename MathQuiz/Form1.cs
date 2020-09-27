using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        private void date(object sender, EventArgs e)
        {
            DateTime todaysDate = DateTime.Now;
            dateLabelBox.Text = todaysDate.ToString("D");
        }

        Random randomizer = new Random();

        int addend1;
        int addend2;

        int minuend;
        int subtrahend;

        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;


            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();

        }

        private bool CheckTheAnswer() 
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))


                return true;
            else
                return false;


        }


        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }
        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft <= 6)
                timeLabel.BackColor = Color.Red;

            if (CheckTheAnswer())
            {
                timer1.Stop();
                SoundPlayer winSound = new SoundPlayer(@"c:\Windows\Media\chimes.wav");
                winSound.Play();
                MessageBox.Show("You got all the answers right!", "Congradulations!");
                startButton.Enabled = true;

            }
            else if (timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            { 
                SoundPlayer looseSound = new SoundPlayer(@"c:\Windows\Media\chord.wav");
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                timeLabel.BackColor = default(Color);
               
                looseSound.Play();
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;

                startButton.Enabled = true;

            }
        }

        private void sum_ValueChanged(object sender, EventArgs e)
        {
            if (sum.Value == addend1 + addend2)
            {
                SoundPlayer sumSound = new SoundPlayer(@"c:\Windows\Media\ding.wav");
                sumSound.Play();

            }
        }
        private void difference_ValueChanged_1(object sender, EventArgs e)
        {
            if (difference.Value == minuend - subtrahend)
            {
                SoundPlayer differenceSound = new SoundPlayer(@"c:\Windows\Media\ding.wav");
                differenceSound.Play();

            }
        }

        private void product_ValueChanged_1(object sender, EventArgs e)
        {
            if (product.Value == multiplicand * multiplier)
            {
                SoundPlayer productSound = new SoundPlayer(@"c:\Windows\Media\ding.wav");
                productSound.Play();

            }
        }
        private void qoutent_ValueChanged_1(object sender, EventArgs e)
        {
            if (quotient.Value == dividend / divisor)
            {
                SoundPlayer qoutentSound = new SoundPlayer(@"c:\Windows\Media\ding.wav");
                qoutentSound.Play();

            }
        }


       
    }
}
