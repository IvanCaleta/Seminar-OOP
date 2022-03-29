using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace sem1
{
    public partial class Form1 : Form
    {
        StreamWriter sw = new StreamWriter("E:/seminar/sem1/sem1/buffer.txt");
        StreamReader sr = new StreamReader("E:/seminar/sem1/sem1/ucitaj.txt");
        public Form1()
        {
            sw.Write("Rezultati:");
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedItem = "EUR";

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Minimum = 0;

            numericUpDown1.Maximum = 25000;

            pretvaraj();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pretvaraj();
        }
        private void pretvaraj()
        {
            decimal broj = this.numericUpDown1.Value;
            string valuta = this.comboBox1.SelectedItem.ToString();
            decimal novo = broj;

            if (valuta == "EUR")
                novo = broj / 7.56m;
            else if (valuta == "USD")
                novo = broj / 6.13m;
            else if (valuta == "RSD")
                novo = broj * 15.55m;
            else if (valuta == "KM")
                novo = broj / 3.88m;
            else if (valuta == "DEN")
                novo = broj * 8.14m;
            else if (valuta == "GBP")
                novo = broj / 8.35m;


            novo = decimal.Round(novo,4,MidpointRounding.AwayFromZero);

            this.label2.Text = novo + " " + valuta;


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Jeste li sigurni?", "Potvrdi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                sw.Write("\nKraj!");
                sr.Close();
                sw.Close();

                this.Close();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            DialogResult f = MessageBox.Show("Ovdje birate u koju valutu želite pretvoriti kune","Pomoć",MessageBoxButtons.OK);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Ovdje unosite određeni iznos u kunama.\nMaksimum je 25000.", "Pomoć", MessageBoxButtons.OK);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = this.label2.Text;
            sw.Write("\n");
            sw.Write(str);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = sr.ReadLine();
            decimal br = System.Convert.ToDecimal(str);
            this.numericUpDown1.Value = br;
            

        }

        private void label6_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Klikom na Ucitaj se ucitava iznos iz mape ucitaj.txt", "Pomoć", MessageBoxButtons.OK);

        }

        private void label5_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Klikom na Spremi se spremaju rezultati u mapu buffer.txt\n", "Pomoć", MessageBoxButtons.OK);

        }
    }
}
