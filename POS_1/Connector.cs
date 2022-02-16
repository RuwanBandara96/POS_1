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

        public Connector()
        {
            String conn_str = "server=localhost;port=3306;username=root;password=gayanu.amb;database=cs_test";
            connection = new MySqlConnection(conn_str);
            security = new Security();
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
