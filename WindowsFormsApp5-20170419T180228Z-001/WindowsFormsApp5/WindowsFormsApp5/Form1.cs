using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "datasource=localhost;port=3306;username=root;password=123456; database= databaseproject;";
            MySqlConnection connect = new MySqlConnection(str);
            MySqlCommand command = new MySqlCommand(" Select * from park_and_ride where Location_ like('" + textBox1.Text + "') ;", connect);
            MySqlDataReader read;
            try
            {
                connect.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    this.chart1.Series["Capacity"].Points.AddXY(read.GetString("location_"), read.GetInt32("Capacity_"));
                }
            }
            finally
            {

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = "datasource=localhost;port=3306;username=root;password=123456; database= databaseproject;";
            MySqlConnection connect = new MySqlConnection(str);
            MySqlCommand command= new MySqlCommand(" Select * from parking_lots where Adress_ like('" + textBox2.Text + "') ;", connect);
            MySqlDataReader read;
            try
            {
                connect.Open();
                read = command.ExecuteReader();
                while (read.Read())
                {
                    this.chart2.Series["Capacity"].Points.AddXY(read.GetString("Adress_"), read.GetInt32("Capacity_"));
                }
            }
            finally
            {

            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string constring = "datasource=localhost;port=3306;username=root;password=123456; database= databaseproject;";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            String str;
            if (textBox3.Text != String.Empty)
            {
                str = " Select * from park_and_ride where Location_ like('" + textBox3.Text + "');";
            }
            else
            {
                str = " Select * from park_and_ride;";
            }

            MySqlDataAdapter cmdDatabase = new MySqlDataAdapter(str, conDataBase);
            DataSet set = new DataSet();
            cmdDatabase.Fill(set);
            dataGridView1.DataSource = set.Tables[0];
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            StringBuilder adress = new StringBuilder();
            adress.Append("http://maps.google.com/maps?q=");

            if (textBox4.Text != String.Empty)
            {
                adress.Append(textBox4.Text + "," + "+");
            }
            webBrowser1.Navigate(adress.ToString());

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            string constring = "datasource=localhost;port=3306;username=root;123456; database= databaseproject";
            MySqlConnection conDataBase = new MySqlConnection(constring);
            String str;
            if (textBox5.Text != String.Empty)
            {
                str = " Select * from parking_lots where Adress_ like('" + textBox5.Text + "');";
            }
            else
            {
                str = " Select * from parking_lots;";
            }

            MySqlDataAdapter cmdDatabase = new MySqlDataAdapter(str, conDataBase);
            DataSet set = new DataSet();
            cmdDatabase.Fill(set);
            dataGridView2.DataSource = set.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 previous= new Form3();
            previous.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
