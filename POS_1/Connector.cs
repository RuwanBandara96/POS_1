using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace POS_1
{
    class Connector
    {
        private MySqlConnection connection;
        private Security security;
        XMLSetitngsReader xsr;

        public Connector()
        {
            xsr = new XMLSetitngsReader();
            String db_server = xsr.ReadValue("db_server");
            String db_port = xsr.ReadValue("db_port");
            String db_user = xsr.ReadValue("db_user");
            String db_password = xsr.ReadValue("db_password");
            String db_db = xsr.ReadValue("db_name");//anjana vakil
            String conn_str = "server="+db_server+";port="+db_port+";username="+db_user+";password="+db_password+";database="+db_db;
            connection = new MySqlConnection(conn_str);
            security = new Security();
        }

        public void createDatabase()
        {
            try
            {
                String sql1 = "create table if not exists users (id integer unsigned not null primary key auto_increment,username varchar(200) not null,password varchar(200) not null,role varchar(200) not null)";
                String sql2 = "create table if not exists items (id integer unsigned not null primary key auto_increment,code varchar(100) not null, name varchar(200) not null,quantity decimal(18,3) not null,price decimal(18,2) not null)";
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sql1, connection);
                cmd.ExecuteNonQuery();
                MySqlCommand cmd2 = new MySqlCommand(sql2, connection);
                cmd2.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public User loginUser(String username,String password)
        {
            String sqlString = "select * from users where username = '" + username + "' && password = '" + security.EncryptData(password) + "'";
            try
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(sqlString,connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                int i = 0,uid = 0;
                String role = "";
                while (rdr.Read())
                {
                    uid = rdr.GetInt32("id");
                    role = rdr.GetString("role");
                    i++;
                }

                if(i == 1)
                {
                    User usr = new User();
                    usr.id =uid;
                    usr.role = role;
                    connection.Close();
                    return usr;

                }
                else
                {
                    connection.Close();
                    throw new Exception("No Usera Found!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int manipulateData(String sqls)
        {
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sqls,connection);
                int ans =  cmd.ExecuteNonQuery();
                connection.Close();
                return ans;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
    class User
    {
        public int id;
        public String role;
    }
}
