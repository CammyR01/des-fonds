using MySql.Data;
using MySql.Data.MySqlClient;

using System.Data;
using System.Data.SqlClient;

namespace des_fonds.Controller
{

// Basic class for connecting to database
//database created through mySQl workbench

    public class DataController
    {
        private MySqlConnection connection;




        public void CreateDatabase()
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




        public void Close()
        {
            connection.Close();
            Console.WriteLine("Connection closed");
        }





        public void createUserTable()
        {
            string utab = "CREATE TABLE user(ID PRIMARY KEY,UName varchar(100),PWD varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
        }

        
        public void addUserEntry(int id, string uName, string pwd)
        {
            string insert = "INSERT INTO users(ID, UName, PWD) VALUES(id, uName, pwd)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public void removeUserEntry(int id, string uName, string pwd)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public void createAddressTable()
        {
            string utab = "CREATE TABLE address(ID PRIMARY KEY,Address varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public void addAddressEntry(int id, string address)
        {
            string insert = "INSERT INTO address(ID,Address) VALUES(id,address)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }

        public void removeAddressEntry(int id, string uName, string pwd)
        {
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        public void createIncomeTable(){}
        
        public void addIncomeEntry(int id, double income){}
        
        public void removeIncomeEntry(int id, double expense){}
        
        public void createExpenseTable(){}
        
        public void addExpenseEntry(int id, double expense){}
        
        public void removeExpenseEntry(int id, double expense){}
        
        
    }
}
    
