using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            MessageBox.Show("All the Fields Are Empty We Don't Apply That.", "Error Occured",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
