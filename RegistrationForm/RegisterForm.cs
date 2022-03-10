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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
      
            new LoginForm().Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connetionString;
            SqlConnection cnn;

            connetionString = @"Data Source=servername;Initial Catalog=RegistrationDB;Integrated Security=SSPI;";
            cnn = new SqlConnection(connetionString);

            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
            String sql;

            try
            {
                if (username.Text != string.Empty && password.Text != string.Empty && confirmpass.Text == password.Text)
                {
                    cnn.Open();

                    sql = "INSERT INTO users (username, password) VALUES('" + username.Text + "', '" + password.Text + "')";


                    command = new SqlCommand(sql, cnn);

                    adapter.InsertCommand = new SqlCommand(sql, cnn);
                    adapter.InsertCommand.ExecuteNonQuery();


                    command.Dispose();
                    cnn.Close();

                    new WelcomePage().Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("All fields are required and password, confirm pass field must be equal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
