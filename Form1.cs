namespace dbmsproj
{
   

    public partial class Form1 : Form
    {

        public static string pswd = "AAAA";
        public static string dob = "September 30, 2001";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            if(textBox2.Text==pswd)
            {
                MessageBox.Show("Welcome " + user);
                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Sorry Wrong Password try again!!!");
                textBox1.Clear();
                textBox2.Clear();     
            }
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}