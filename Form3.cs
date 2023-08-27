using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbmsproj
{
    public partial class Form3 : Form
    {
        public static int agegrp;
        Int32 age;
        public Form3()
        {

            InitializeComponent();

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (agegrp == 3 || agegrp == 4)
            {
                Form4 f4 = new Form4();
                f4.Show();
            }
            else
            {
                Form5 f5 = new Form5();
                f5.Show();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            age = Int32.Parse(textBox1.Text);
            if (age < 10)
            {
                agegrp = 1;
                radioButton1.PerformClick();

            }
            else if (age >= 10 & age < 18)
            {
                agegrp = 2;
                radioButton2.PerformClick();
            }
            else if (age >= 18 & age < 60)
            {
                agegrp = 3;
                radioButton3.PerformClick();
            }
            else
            {
                agegrp = 4;
                radioButton4.PerformClick();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
