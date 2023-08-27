using Microsoft.VisualBasic.Devices;
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
    public partial class Form4 : Form
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private DataTable dt;
        private DataSet ds;
        private SqlDataAdapter da;
        private DataRow dr;

        public Form4()
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
            comboBox2.Items.Add("Romance");
            comboBox2.Items.Add("Horror");
            comboBox2.Items.Add("Comedy");


        }
        public void DbConnect()
        {
            String sqdb = @"Data Source=desktop-ogk9b1f;Integrated Security=True";
            conn = new SqlConnection(sqdb);
            //conn = new SqlCommand();
            conn.Open();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true && checkBox2.Checked==true)
            {
                DbConnect();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from movie where language='" + comboBox1.Text + "'and genre='"+comboBox2.Text+"'";
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
                cmd.CommandText = "select * from movie where language='"+comboBox1.Text+"'";
                cmd.CommandType = CommandType.Text;
                //ds = new DataSet();
                SqlParameter pa1 = new SqlParameter();
                
                
                da = new SqlDataAdapter(cmd.CommandText, conn);
           
                DataSet ds = new DataSet();
               
                da.Fill(ds, "tb_movie");
                dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
               
            }
            else if(checkBox1.Checked == true)
            {
                DbConnect();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from movie where genre='" + comboBox2.Text + "'";
                cmd.CommandType = CommandType.Text;
                //ds = new DataSet();
                SqlParameter pa1 = new SqlParameter();


                da = new SqlDataAdapter(cmd.CommandText, conn);

                DataSet ds = new DataSet();

                da.Fill(ds, "tb_movie");
                dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;


            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from movie order by box_office desc";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movie.id,movie.title,movie.release_date,rating.IMDB from movie,rating where movie.id=rating.id order  by IMDB desc";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movie.id,movie.title,movie.release_date,rating.rt_criticscore from movie,rating where movie.id=rating.id order  by rt_criticscore desc ";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movie.id,movie.title,movie.release_date,rating.metacritic from movie,rating where movie.id=rating.id order by metacritic desc";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select movie.id, movie.title, movie.release_date, movie.genre, accolade.award_name, accolade.no_of_awards_won, accolade.no_of_nominations from movie, accolade where movie.id= accolade.id";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;


        }

        private void button7_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "(select * from movie)except(select * from movie where box_office<some (select box_office from movie))";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "(select * from movie)except(select * from movie where box_office>some (select box_office from movie))";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DbConnect();
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from movie";
            cmd.CommandType = CommandType.Text;
            //ds = new DataSet();
            SqlParameter pa1 = new SqlParameter();


            da = new SqlDataAdapter(cmd.CommandText, conn);

            DataSet ds = new DataSet();

            da.Fill(ds, "tb_movie");
            dataGridView1.DataSource = ds.Tables["tb_movie"].DefaultView;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
