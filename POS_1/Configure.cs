using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace POS_1
{
    public partial class ConfigureForm : Form
    {
        private Security security;
        private Connector connector;
        private string db_name, db_password, db_username, db_host, db_port;
        private String configfile;
        public ConfigureForm(String  fname)
        {
            InitializeComponent();
            security = new Security();
            configfile = fname;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dbconfig();
            //text connection
            try
            {
                String conn_str = "server="+db_host+";port="+db_port+";username="+db_username+";password="+db_password+";database="+db_name;
                MySqlConnection connection = new MySqlConnection(conn_str);
                connection.Open();
                if(connection.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connection Test Success!");
                }
                else
                {
                    MessageBox.Show("connection Test Failed!");
                }
                connection.Close();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dbconfig();
            //write to xml
            try
            {
                XDocument dmt = new XDocument(new XElement("root", new XElement("db_name", db_name), new XElement("db_user", db_username),
                new XElement("db_password", db_password), new XElement("db_server", db_host), new XElement("db_port", db_port)));
                dmt.Save(configfile);
                MessageBox.Show("Successfully Completed");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connector = new Connector();
            try
            {
                connector.createDatabase();
                MessageBox.Show("Successfully Created!");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dbconfig()
        {
            db_host = textBox8.Text;
            db_port = textBox4.Text;
            db_username = textBox3.Text;
            db_password = textBox2.Text;
            db_name = textBox1.Text;
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
                    Application.Exit();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Password is wrong");
            }

        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
