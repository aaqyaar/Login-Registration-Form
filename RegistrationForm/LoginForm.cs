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

namespace RegistrationForm
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            new RegisterForm().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=servername;Initial Catalog=RegistrationDB;Integrated Security=SSPI;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                SqlCommand command;
                SqlDataReader dataReader;
                String sql, Output = "";
                if (loginUserName.Text != string.Empty && loginPassword.Text != string.Empty)
                {


                    sql = "SELECT * FROM users WHERE username = '" + loginUserName.Text + "' and password = '" + loginPassword.Text + "'";

                    command = new SqlCommand(sql, cnn);

                    dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        
                        new WelcomePage().Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("We don't get your username or password in the DB! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataReader.Close();

                    }


                    command.Dispose();
                    cnn.Close();
                } else
                {
                    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! ");
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
