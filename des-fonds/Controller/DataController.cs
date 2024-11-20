using MySql.Data;
using MySql.Data.MySqlClient;

using System.Data;
using System.Data.SqlClient;

namespace des_fonds.Controller
{

// Basic class for connecting to database
//database created through mySQl workbench

    public static class DataController
    {
        private static MySqlConnection connection;

        
        
        
        
        public static void CreateDatabase()
        {
            string connString = "Server=192.168.0.208; port=3306; user=group18; password=password; database=defundsdb";
            
            connection = new MySqlConnection(connString);
            
            if (connection.State == ConnectionState.Closed)
            {


                try
                {
                    connection.Open();
                    //Console.WriteLine("Connection established");
                    //MySqlCommand sqlCommand = new MySqlCommand("CREATE DATABASE " + cDB, connection);
                    //sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    
                    throw new Exception("couldnt connect");
                }

                
            }

        }




        public static void Close()
        {
            connection.Close();
            Console.WriteLine("Connection closed");
        }





        public static void CreateUserTable()
        {


            
            string utab = "CREATE TABLE user" +
                "(ID INT PRIMARY KEY AUTO_INCREMENT, UName VARCHAR(100), PWD VARCHAR(100))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
        }

        
        public static void AddUserEntry(int id, string uName, string pwd)
        {
            string insert = "INSERT INTO users(ID, UName, PWD) VALUES(id, uName, pwd)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public static void RemoveUserEntry(int id, string uName, string pwd)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        public static void UpdateUserEntry(int id, string uName)
        {
            string update = "UPDATE users SET UName = @uName WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(update, connection);  
            qCmd.ExecuteNonQuery();
        }
        public static void GetUserEntry(int id, string uName)
        {
            string select = "SELECT FROM users WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(select, connection);  
            qCmd.ExecuteNonQuery();
        }
        
        public static void CreateAddressTable()
        {
            string atab = "CREATE TABLE address(ID PRIMARY KEY,Address varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(atab, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public static void AddAddressEntry(int id, string address)
        {
            string insert = "INSERT INTO address(ID,Address) VALUES(id,address)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public static void RemoveAddressEntry(int id, string address)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        public static void UpdateAddressEntry(int id, string address){}

        public static void GetAddressEntry(int id, string address)
        {
            
        }
        
        public static void CreateStatementTable()
        {
            string stab = "CREATE TABLE statement(source varchar(100),amount varchar(100), date datetime,type varchar(100))";
            MySqlCommand qcmd = new MySqlCommand(stab, connection);
            qcmd.ExecuteNonQuery();
        }
        
        public static void addIncomeEntry(string source,double amount, DateTime date)
        {//other way to do this is by passing income class and using getter in insert statement
            //Income income
            //income.source
            //income.amount
            //income.date
            string insert = "INSERT INTO statement(source,amount,date,INCOME) VALUES(source,amount,date)";
                        MySqlCommand qCmd = new MySqlCommand(insert, connection);
                        qCmd.ExecuteNonQuery();
            
        }

        public static void removeIncomeEntry(int id, double expense)
        {
            
        }


        public static void addExpenseEntry(string source,double expense,DateTime date)
        {
            string insert = "INSERT INTO statement(source,amount,date,EXPENSE) VALUES(source,amount,date)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public static void removeExpenseEntry(int id, double expense){}
        
        public static void GetStatementTable()
        {
        }
        
    }
    
}
    
