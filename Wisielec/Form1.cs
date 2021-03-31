using System;
using System.Windows.Forms;

namespace Wisielec
{
    public partial class Form1 : Form
    {
        private string word;
        private int tryNumber = 0;
        private int faults = 0;
        private int success = 0;

        public Form1()
        {
            InitializeComponent();

            startGame();
        }

        private void startGame()
        {
            word = setRandomWord();
            label1.Text = Convert.ToString(word[0]);
            label2.Text = "_";
            label3.Text = "_";
            label4.Text = "_";
            label5.Text = "_";
            label6.Text = "_";
            label7.Text = Convert.ToString(word[6]);
        }

        private static string setRandomWord()
        {
            string[] words = { "tulipan", "marchew", "potwarz", "kompakt", "telefon", "frędzel", "pokemon", "majster", "patefon", "program", "piernik", "elegant", "bateria" };
            Random gen = new Random();
            int i = gen.Next(0, words.Length);

            return words[i];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean flag = false;
            tryNumber++;

            for (int i = 1; i < 6; i++)
            {
                if (Convert.ToString(word[i]).Equals(textInput.Text))
                {
                    flag = true;
                    success++;

                    if (i == 1) { label2.Text = textInput.Text; }
                    if (i == 2) { label3.Text = textInput.Text; }
                    if (i == 3) { label4.Text = textInput.Text; }
                    if (i == 4) { label5.Text = textInput.Text; }
                    if (i == 5) { label6.Text = textInput.Text; }

                    if (success == 5)
                    {
                        button1.Enabled = false;
                        button1.Text = "WYGRAŁEŚ!";
                    }
                }
            }

            textInput.Text = "";

            if (!flag)
            {
                faults++;
                setImage();
            }
        }

        private void setImage()
        {
            if (faults == 1) { pictureBox1.Image = Wisielec.Properties.Resources._1; }
            if (faults == 2) { pictureBox1.Image = Wisielec.Properties.Resources._2; }
            if (faults == 3) { pictureBox1.Image = Wisielec.Properties.Resources._3; }
            if (faults == 4) { pictureBox1.Image = Wisielec.Properties.Resources._4; }
            if (faults == 5)
            {
                pictureBox1.Image = Wisielec.Properties.Resources._5;
                button1.Text = "PRZEGRAŁEŚ";
                button1.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1.PerformClick();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tryNumber = 0;
            faults = 0;
            success = 0;

            button1.Enabled = true;
            button1.Text = "Sprawdź";

            pictureBox1.Image = null;
            startGame();
        }
    }
}