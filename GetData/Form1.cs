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
using MySql.Data.MySqlClient;

namespace GetData
{
    public partial class FormLogin : Form
    {
        
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection sqlConnection;
            MySqlConnection mysqlConnection;

            string connection = textBoxConnection.Text;
            string database = textBoxDatabase.Text;
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            //SQL Server Connection
            if(comboBoxSelectDB.Text=="SQL DB")
            {
                //Production DB
                connectionString = @"Data Source=" + connection + ";Initial Catalog=" + database + ";User ID=" + user + ";Password=" + password + "";
                sqlConnection = new SqlConnection(connectionString);

                //Develop DB
                //connectionString = @"Data Source=localhost;Initial Catalog=Application;User ID=dbuser;Password=dbpass";

                try
                {
                    sqlConnection.Open();
                    MessageBox.Show("Connection Open!");
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.Message);
                }

                //begin select

                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";

                sql = "Select *from user";
                command = new SqlCommand(sql, sqlConnection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
                }

                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
                sqlConnection.Close();


                //end select
                sqlConnection.Close();

            }

            //MySQL Server Connection 
            if(comboBoxSelectDB.Text == "MySQL DB")
            {
                connectionString = "server=localhost;user id=root;password=5edd4dXm0;database=testdb";
                mysqlConnection = new MySqlConnection(connectionString);

                try
                {
                    mysqlConnection.Open();
                    MessageBox.Show("Connection Open!");
                }
                catch (SqlException error)
                {
                    MessageBox.Show(error.Message);
                }

                //begin select

                MySqlCommand command;
                MySqlDataReader dataReader;
                String sql, Output = "";

                sql = "SELECT * FROM testdb.employees;";
                command = new MySqlCommand(sql, mysqlConnection);
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Output = Output + dataReader.GetValue(0) + " - " + dataReader.GetValue(1) + "\n";
                }

                MessageBox.Show(Output);

                dataReader.Close();
                command.Dispose();
                mysqlConnection.Close();


                //end select

                mysqlConnection.Close();

            }

            //Select your DB!!!
            else
            {
                MessageBox.Show("Select DB!");

            }

        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            SelectWTF SelectWTFClass = new SelectWTF();
        }
    }
}
