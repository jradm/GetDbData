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

            string connection = textBoxConnection.Text;
            string database = textBoxDatabase.Text;
            string user = textBoxUser.Text;
            string password = textBoxPassword.Text;

            //Develop DB
            connectionString = @"Data Source=localhost;Initial Catalog=Application;User ID=dbuser;Password=dbpass";

            //Production DB
            //connectionString = @"Data Source="+ connection +";Initial Catalog="+ database +";User ID="+ user +";Password="+ password +"";

            sqlConnection = new SqlConnection(connectionString);

            
            try
            {
                sqlConnection.Open();
                MessageBox.Show("Connection Open!");
            }
            catch (SqlException error)
            {
                MessageBox.Show(error.Message);
            }

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select username, password from Application";


            sqlConnection.Close();
        }
    }
}
