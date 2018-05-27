using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class Form1 : Form
    {
        private List<string> randomNumber;
        private List<string> input;

        public Form1()
        {
            InitializeComponent();
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            randomNumber = new List<string>();
            string select = "";
            Random num = new Random();
            int i = 0;
            while (i < 4)
            {
                select = num.Next(0, 9).ToString();
                bool a = randomNumber.Contains(select);
                if (a)
                {
                    select = num.Next(0, 9).ToString();
                }
                else
                {
                    randomNumber.Add(select);
                    i++;
                }
            }
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = new List<string>();
            for (int i = 0; i < 4; i++)
            {
                input.Add(textBox1.Text.Substring(i, 1));
            }
            var B = input.Intersect(randomNumber).Count();
            var A = 0;
            foreach (var i in randomNumber)
            {
                if (input[randomNumber.IndexOf(i)] == i)
                {
                    A = A + 1;
                }
            }
            B = B - A;
            textBox2.Text = textBox2.Text + textBox1.Text + " : " + A.ToString() + "A" + B.ToString() + "B" + Environment.NewLine;
            if (A == 4)
                MessageBox.Show("過關");
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string answer = "";
            foreach (var b in randomNumber)
            {
                answer = answer + b;
            }
            MessageBox.Show(answer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
    }
}
