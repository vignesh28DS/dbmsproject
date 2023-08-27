using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace dbmsproj
{
    public partial class Form6 : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataRow dr;
        public Form6()
        {
            InitializeComponent();
        }
        public void DbConnect()
        {
            String sqdb = @"Data Source=desktop-ogk9b1f;Integrated Security=True";
            conn = new SqlConnection(sqdb);
            //conn = new SqlCommand();
            conn.Open();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select C.id,title,language,genre,age_rating,box_office,director,lead_male,lead_female from castNcrew C,movie M where M.id=C.id and (lead_male like'"+textBox1.Text+"'or lead_female like'"+textBox1.Text+"'or director like'"+textBox1.Text+"'or title like'"+textBox1.Text+"')";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
