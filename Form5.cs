using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

namespace dbmsproj
{
    public partial class Form5 : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataRow dr;

        public Form5()
        {
            InitializeComponent();
            comboBox1.Items.Add("English");
            comboBox1.Items.Add("Hindi");
            comboBox1.Items.Add("Telgu");
            comboBox1.Items.Add("Tamil");
            comboBox1.Items.Add("Japanese");
            comboBox2.Items.Add("Action");
            comboBox2.Items.Add("Thriller");
            comboBox2.Items.Add("Drama");
            comboBox2.Items.Add("Comedy");
            
        }
        public void DbConnect()
        {
            String sqdb = @"Data Source=desktop-ogk9b1f;Integrated Security=True";
            conn= new SqlConnection(sqdb);
            //conn = new SqlCommand();
            conn.Open();

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true && checkBox2.Checked == true)
            {
                DbConnect();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from movie where (age_rating<>'R' and age_rating<>'A') and language='" + comboBox1.Text + "'and genre='" + comboBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                //ds = new DataSet();
                SqlParameter pa1 = new SqlParameter();


                da = new SqlDataAdapter(cmd.CommandText, conn);

                DataSet ds = new DataSet();

                da.Fill(ds, "tb_movie");
                dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
            }
            else if (checkBox1.Checked == true)
            {
                DbConnect();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from movie where (age_rating<>'R' and age_rating<>'A') and language='" + comboBox1.Text + "'";
                cmd.CommandType = CommandType.Text;
                //ds = new DataSet();
                SqlParameter pa1 = new SqlParameter();


                da = new SqlDataAdapter(cmd.CommandText, conn);

                DataSet ds = new DataSet();

                da.Fill(ds, "tb_movie");
                dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;

            }
            else if (checkBox2.Checked == true)
            {
                DbConnect();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from movie where (age_rating<>'R' and age_rating<>'A') and genre='" + comboBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                //ds = new DataSet();
                SqlParameter pa1 = new SqlParameter();


                da = new SqlDataAdapter(cmd.CommandText, conn);

                DataSet ds = new DataSet();

                da.Fill(ds, "tb_movie");
                dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movie.id,movie.title,movie.release_date,movie.duration,castNcrew.distributor from movie,castNcrew where movie.id=castNcrew.id and (castNcrew.distributor='pixar' or castNcrew.distributor='illumination') ";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from movie where age_rating<>'A' and age_rating<>'R'";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }
    }
}
