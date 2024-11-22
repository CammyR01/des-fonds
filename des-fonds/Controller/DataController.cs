using des_fonds.Users;
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

        
        
        
        
        public static void OpenConnection()
        {
            string connString = "Server=80.195.174.63; port=3306; user=group18; password=password; database=defundsdb; sslMode=Required";
            
            connection = new MySqlConnection(connString);
            
            if (connection.State == ConnectionState.Closed)
            {


                try
                {
                    connection.Open();
                    Console.WriteLine("connection successful");
                    //Console.WriteLine("Connection established");
                    //MySqlCommand sqlCommand = new MySqlCommand("CREATE DATABASE " + cDB, connection);
                    //sqlCommand.ExecuteNonQuery();
                }
                catch
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
            OpenConnection();
            string utab = "CREATE TABLE users" +
                "(ID INT PRIMARY KEY AUTO_INCREMENT," +
                "First_Name VARCHAR(35)," +
                "Last_Name VARCHAR(35)," +
                "Age INT," +
                "UName VARCHAR(45)," +
                "PWD VARCHAR(255))";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
            Close();
        }

        
        public static void AddUserEntry(int id,string first_name, string last_name, int age, string uName, string pwd)
        {
            OpenConnection();
            string insert = "INSERT INTO users(ID, First_name, Last_Name, Age, UName, PWD) " +
                "VALUES(@id, @first_name, @last_name, @age, @uName, @pwd)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);

            //adding parameters
            qCmd.Parameters.AddWithValue("@id", id);
            qCmd.Parameters.AddWithValue("@first_name", first_name);
            qCmd.Parameters.AddWithValue("@last_name", last_name);
            qCmd.Parameters.AddWithValue("@age", age);
            qCmd.Parameters.AddWithValue("@uName", uName);
            qCmd.Parameters.AddWithValue("@pwd", pwd);
            
            qCmd.ExecuteNonQuery();
            Close();
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
        public static User GetUserEntry(int id, string uName)
        {
            OpenConnection();
            string select = "SELECT ID, First_Name, Last_Name, Age, UName FROM users WHERE ID = @ID";
            using (MySqlCommand command = new MySqlCommand(select, connection))
            {
                command.Parameters.AddWithValue("@ID", id);

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32("ID");
                        string fname = reader["First_Name"].ToString();
                        string lname = reader["Last_Name"].ToString();
                        int age = int.Parse(reader["Age"].ToString());
                        string uname = reader["UName"].ToString();
                        Close();
                        return new User(userId, fname, lname, age, uname);
                        
                    }
                    else
                    {
                        Close();
                        throw new Exception("User not found");
                    }
                }
            }

            
        }
        
        public static void CreateAddressTable()
        {
            string atab = "CREATE TABLE address(ID int PRIMARY KEY,Address varchar(100))";
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
        public static void UpdateAddressEntry(int id, string address)
        {
            string update = "UPDATE address SET Address = @address WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand();
            qCmd.ExecuteNonQuery();
        }

        public static void GetAddressEntry(int id, string address)
        {
            string get = "SELECT FROM address where ID = @id";
            MySqlCommand qCmd = new MySqlCommand(get, connection);
            qCmd.ExecuteNonQuery();
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

        public static void removeIncomeEntry(string source, double amount, DateTime date)
        {
            string delete ="DELETE from statement WHERE source = @source amount = @amount date = @date type = INCOME";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
        }


        public static void addExpenseEntry(string source,double expense,DateTime date)
        {
            string insert = "INSERT INTO statement(source,amount,date,EXPENSE) VALUES(source,amount,date)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);
            qCmd.ExecuteNonQuery();
        }
        
        public static void removeExpenseEntry(string source, double expense, DateTime date)
        {

        }
        
        public static void GetStatementTable(DateTime date)
        {
            string get = "SELECT from statement WHERE date = @date";
            MySqlCommand qCmd = new MySqlCommand(get,connection);
            qCmd.ExecuteNonQuery();
        }
        
    }
    
}
    
