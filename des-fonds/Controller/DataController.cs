using MySql.Data.MySqlClient;

using System.Data;

namespace des_fonds.Controller
{

    // Basic class for connecting to database
    //database created through mySQl workbench

    public static class DataController
    {
        private static MySqlConnection connection;

        
        
        
        
        public static void CreateDatabase()
        {
            string connString = "Server=127.0.0.1; port=3307; user=root; password=password;";
            string cDB = "DB";
            connection = new MySqlConnection(connString);
            
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
            string utab = "CREATE TABLE user(ID PRIMARY KEY,UName varchar(100),PWD varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
        }

        
        public static void AddUserEntry(int id, string uName, string pwd)
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
        public static void updateUserEntry(int id, string uName)
        {
            string update = "UPDATE users SET UName = @uName WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(update, connection);  
            qCmd.ExecuteNonQuery();
        }
        public static void getUserEntry(int id, string uName)
        {
            string select = "SELECT FROM users WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(select, connection);  
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
        public static void updateAddressEntry(int id, string address){}
        
        public static void getAddressEntry(int id, string address){}
        
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
    
