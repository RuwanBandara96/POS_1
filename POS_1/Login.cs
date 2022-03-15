using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace POS_1
{
    public partial class Login : Form
    {
        private Connector connector;
        private Security security;
        XMLSetitngsReader xsr;
        public Login()
        {
            InitializeComponent();
            xsr = new XMLSetitngsReader();
            //xsr.InsertItem("database", "hello_db");
            //xsr.InsertItem("code", "dont oknow");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
            connector = new Connector();
             String username, password;
             username = textBox1.Text;
             password = textBox2.Text;

             try
             {
                 User usr = connector.loginUser(username, password);

                Properties.Settings.Default.userid = usr.id;
                Properties.Settings.Default.userrole = usr.role;
                Dashboard dbx = new Dashboard();
                dbx.Visible = true;
                this.Visible = false;
            }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            security = new Security();
        }
    }
}
