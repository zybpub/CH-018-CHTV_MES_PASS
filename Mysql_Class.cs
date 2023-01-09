using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace colortv_test_automation
{
    class Mysql_Class
    {
        //方法一：Visual Studio,在 项目(右键)-管理NuGet程序包(N)  然后在浏览里面搜索MySql.Data并进行安装。

        //方法二：安装数据库MySQL时要选中Connector.NET 6.9的安装，将C:\Program Files(x86)\MySQL\Connector.NET 6.9\Assemblies里v4.0或v4.5中的MySql.Data.dll添加到项目的引用。
        //v4.0和v4.5，对应Visual Studio具体项目 属性-应用程序-目标框架 里的.NET Framework的版本号。
        private MySqlConnection connection;
        //private string server;
        //private string database;
        //private string uid;
        //private string password;

        //Constructor
        public Mysql_Class()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            //server = "localhost";
            //database = "jczx_mysql_db";
            //uid = "root";
            //password = "jczx";

            string connectionString;
            connectionString = "SERVER=" + passmes_config_json.Mysql_IP + ";" 
                + "DATABASE=" + passmes_config_json.mysql_database_name + ";" 
                + "UID=" + passmes_config_json.Mysql_User + ";" + "PASSWORD=" + passmes_config_json.Mysql_Pass + ";charset=gb2312";

            connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (id,name, age) VALUES('11','John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string query = "UPDATE tableinfo SET id='22', name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete(int id)
        {
            string query = "DELETE FROM tableinfo WHERE id=" + id;

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        //Select statement
        public List<string>[] Select()
        {
            string query = "SELECT * FROM laiyatest";

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["tid"] + "");
                    list[1].Add(dataReader["tdatetime"] + "");
                    list[2].Add(dataReader["result"] + "");
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }
        }

        //Count statement
        public int Count()
        {
            string query = "SELECT Count(*) FROM tableinfo";
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }

      
        internal static string InsertDataV20(Class_Passmes_Data_V10 d)
        {
            string query = "";
            try
            {
                string good = "0";
                if (d.良品 == true) good = "1";

                query = "INSERT INTO `passmes_data` ( `MO`, `SN`, `WORKSTATIONID`, `SOFT_VER`, `ERROR_CODE`,`ERROR_SPOT`, `testdate`,`testseconds`,"
                   + " `result`,  `isgood`, `mesreply`,`memo`) VALUES('"
                   + d.MO + "','"
                   + d.SN + "','"
                   + d.WORKSTATIONID + "','"
                   + d.SOFT_VER + "','"
                   + d.ERROR_CODE + "','"
                    + d.ERROR_SPOT + "','"
                   + d.调试时间 + "','"
                    + d.调试时长 + "','"

                   + d.RESULT + "',"
                 
                   + good + ",'"
                   + d.mesreply + "','"
                   + d.memo
                   + "')";

                //return query;

                MySql.Data.MySqlClient.MySqlConnection Conn =
                 new MySql.Data.MySqlClient.MySqlConnection("Database=" + passmes_config_json.mysql_database_name + ";Data Source=" +
                 passmes_config_json.Mysql_IP + ";User Id=" + passmes_config_json.Mysql_User + ";Password=" + passmes_config_json.Mysql_Pass + ";charset=utf8;");
                Conn.Open();

                //create command and assign the query and connection from the constructor
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(query, Conn);
                //Execute command
                cmd.ExecuteNonQuery();
                Conn.Close();
            }
            catch 
            {
                // return ex.ToString();
                return query;
            }
            return "本地数据保存成功";

        }
    }
}















