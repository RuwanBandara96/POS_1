using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS_1
{
    public partial class ConfigureForm : Form
    {
        private Security security;
        private Connector connector;
        public ConfigureForm()
        {
            InitializeComponent();
            security = new Security();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //configure connnection
            connector = new Connector();

            ///configure first user
            String username, password, passwordAgain, role = "Admin";
            username = textBox5.Text;
            password = textBox6.Text;
            passwordAgain = textBox7.Text;

            if (password.Equals(passwordAgain))
            {
                String sqlString = "insert into users(username,password,role)values('" + username + "','" + security.EncryptData(password) + "','" + role + "')";
                try
                {
                    connector.manipulateData(sqlString);
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password is wrong");
            }

            Application.Exit();

        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {

        }
    }
}
