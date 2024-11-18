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
            string connstring = "Data Source = localhost, Integrated Security = True, initial catalog = des_fonds;";
            string cDB = "DB";
            connection = new MySqlConnection(connstring);
            
            if (connection.State == ConnectionState.Closed)
            {


                try
                {
                    connection.Open();
                    Console.WriteLine("Connection established");
                    MySqlCommand sqlCommand = new MySqlCommand("CREATE DATABASE " + cDB, connection);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                
            }

        }




        public static void Close()
        {
            connection.Close();
            Console.WriteLine("Connection closed");
        }





        public static void createUserTable()
        {
            string utab = "CREATE TABLE user(ID PRIMARY KEY,UName varchar(100),PWD varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
        }

        
        public static void addUserEntry(int id, string uName, string pwd)
        {
            string insert = "INSERT INTO users(ID, UName, PWD) VALUES(id, uName, pwd)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public static void removeUserEntry(int id, string uName, string pwd)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public static void createAddressTable()
        {
            string atab = "CREATE TABLE address(ID PRIMARY KEY,Address varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(atab, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public static void addAddressEntry(int id, string address)
        {
            string insert = "INSERT INTO address(ID,Address) VALUES(id,address)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public static void removeAddressEntry(int id, string uName, string pwd)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }

        
        public static void createIncomeTable()
        {
            string itab = "CREATE TABLE income(source varchar(100), amount varchar(100), date datetime)";
            MySqlCommand qcmd = new MySqlCommand(itab, connection);
            qcmd.ExecuteNonQuery();
        }
        
        public static void addIncomeEntry(string source, double income, DateTime date)
        {
            string insert = "INSERT INTO income(source,amount,date) VALUES(source,income,date)";
                        MySqlCommand qCmd = new MySqlCommand(insert, connection);
                        qCmd.ExecuteNonQuery();
            
        }

        public static void removeIncomeEntry(int id, double expense)
        {
            
        }

        
        public static void createExpenseTable()
        {
            string etab = "CREATE TABLE expense(source varchar(100), amount varchar(100), date datetime)";
            MySqlCommand qcmd = new MySqlCommand(etab, connection);
            qcmd.ExecuteNonQuery();
        }
        
        public static void addExpenseEntry(int id, double expense){}
        
        public static void removeExpenseEntry(int id, double expense){}
        
        
    }
}
    
