using des_fonds.Finances;
using des_fonds.Users;
using MySql.Data;
using MySql.Data.MySqlClient;

using System.Data;
using System.Data.SqlClient;
using System.Transactions;

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
                "First_Name VARCHAR(35) NOT NULL," +
                "Last_Name VARCHAR(35) NOT NULL," +
                "Age INT NOT NULL," +
                "UName VARCHAR(45) NOT NULL," +
                "PWD VARCHAR(255) NOT NULL)";
            MySqlCommand qCmd = new MySqlCommand(utab, connection);
            qCmd.ExecuteNonQuery();
            Close();
        }
        public static void CreateAddressTable()
        {
            OpenConnection();
            string atab = "CREATE TABLE addresses" +
                "(ID int PRIMARY KEY AUTO_INCREMENT," +
                "street varchar(50) NOT NULL," +
                "postcode VARCHAR(10) NOT NULL," +
                "city VARCHAR(50) NOT NULL," +
                "country VARCHAR(50) NOT NULL," +
                "user_id INT NOT NULL," +
                "FOREIGN KEY (user_id) REFERENCES users(ID))";
            MySqlCommand qCmd = new MySqlCommand(atab, connection);
            qCmd.ExecuteNonQuery();
        }

        public static void CreateStatementTable()
        {
            string stab = "CREATE TABLE statement" +
                "(ID  int PRIMARY KEY AUTO_INCREMENT," +
                "source varchar(100) NOT NULL," + 
                "amount varchar(100)," + 
                "date datetime," + 
                "type ENUM('INCOME','EXPENSE') NOT NULL," +
                 "user_id INT NOT NULL," +
                "FOREIGN KEY (user_id) REFERENCES users(ID))";
            MySqlCommand qcmd = new MySqlCommand(stab, connection);
            qcmd.ExecuteNonQuery();
        }

        public static void CreateMessageTable()
        {
            OpenConnection();
            string create = "CREATE TABLE message";
        }


        public static void AddUserEntry(string first_name, string last_name, int age, string uName, string pwd, string street, string postcode, string city, string country, out int lastId)
        {
            try
            {
                OpenConnection();
                string insert = "INSERT INTO users(First_name, Last_Name, Age, UName, PWD) " +
                    "VALUES(@first_name, @last_name, @age, @uName, @pwd)";
                MySqlCommand qCmd = new MySqlCommand(insert, connection);

                //adding parameters
                
                qCmd.Parameters.AddWithValue("@first_name", first_name);
                qCmd.Parameters.AddWithValue("@last_name", last_name);
                qCmd.Parameters.AddWithValue("@age", age);
                qCmd.Parameters.AddWithValue("@uName", uName);
                qCmd.Parameters.AddWithValue("@pwd", pwd);

                qCmd.ExecuteNonQuery();
                string getLastId = "SELECT LAST_INSERT_ID()";
                using MySqlCommand lastIdcmd = new MySqlCommand(getLastId, connection);
                lastId = Convert.ToInt32(lastIdcmd.ExecuteScalar());

                string insertAddress = "INSERT INTO addresses(street, postcode, city, country, user_id)" +
                    "VALUES(@street, @postcode, @city, @country, @user_id)";
                MySqlCommand addAddress = new MySqlCommand(insertAddress, connection);

                //adding parameters
                addAddress.Parameters.AddWithValue("@street", street);
                addAddress.Parameters.AddWithValue("@postcode", postcode);
                addAddress.Parameters.AddWithValue("@city", city);
                addAddress.Parameters.AddWithValue("@country", country);
                addAddress.Parameters.AddWithValue("@user_id", lastId);

                addAddress.ExecuteNonQuery();


                Close();

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(int id, string uName, string pwd)
        {
            OpenConnection();
            string delete = "DELETE FROM users WHere ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        public static void UpdateUserEntry(int id, string uName,string fname,string Lname)
        {
            OpenConnection();
            string update = "UPDATE users SET UName = @uName, First_Name = @fname, Last_Name = @lname WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(update, connection);  
           
            qCmd.Parameters.AddWithValue ("@id", id);
            qCmd.Parameters.AddWithValue("@uName", uName);
            qCmd.Parameters.AddWithValue("@fname", fname);
            qCmd.Parameters.AddWithValue("@lname", Lname);

            qCmd.ExecuteNonQuery();
        }
        public static User GetUserEntry(string uName)
        {
            
            OpenConnection();
            string select = "SELECT u.ID, u.First_Name, u.Last_Name, u.Age, u.UName, u.PWD," +
                " a.street, a.postcode, a.city, a.country" +
                " FROM users u" +
                " LEFT JOIN addresses a ON u.ID = a.user_id" +
                " WHERE UName = @uName";
            using (MySqlCommand command = new MySqlCommand(select, connection))
            {
                command.Parameters.AddWithValue("@uName", uName);
                

                using(MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int userId = reader.GetInt32(0);
                        string fname = reader.GetString(1);
                        string lname = reader.GetString(2);
                        int age = reader.GetInt32(3);
                        string uname = reader.GetString(4);
                        string pwd = reader.GetString(5);
                        string street = reader.GetString(6);
                        string postcode = reader.GetString(7);
                        string city = reader.GetString(8);
                        string country = reader.GetString(9);
                        Close();
                        return new User(userId, uname, pwd, fname, lname, age, street, postcode, city, country);
                        
                    }
                    else
                    {
                        Close();
                        throw new Exception("User not found");
                    }
                }
            }

            
        }
        
        
        
    //    public static void AddAddressEntry(int id, string address,)
      //  {
        //    string insert = "INSERT INTO address(ID,Address) VALUES(id,address)";
         //   MySqlCommand qCmd = new MySqlCommand(insert, connection);
          //  qCmd.ExecuteNonQuery();
       // }

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
        
      //  public static void CreateStatementTable()
        //{
          //  string stab = "CREATE TABLE statement(source varchar(100),amount varchar(100), date datetime,type varchar(100))";
            //MySqlCommand qcmd = new MySqlCommand(stab, connection);
            //qcmd.ExecuteNonQuery();
        //}
        
        public static void addIncomeEntry(string source,double amount, DateTime date, string type, int uid)
        {//other way to do this is by passing income class and using getter in insert statement
            //Income income
            //income.source
            //income.amount
            //income.date
            OpenConnection();
            string insert = "INSERT INTO statement(source,amount,date,type,user_id) VALUES(@source,@amount,@date,@type,@uid)";
                        MySqlCommand qCmd = new MySqlCommand(insert, connection);
            
            qCmd.Parameters.AddWithValue("@source", source);
            qCmd.Parameters.AddWithValue("@amount", amount);
            qCmd.Parameters.AddWithValue("@date", date);
            qCmd.Parameters.AddWithValue("@type", type);
            qCmd.Parameters.AddWithValue("@uid", uid);
            
            
            qCmd.ExecuteNonQuery();
            
        }

        public static void removeIncomeEntry(string source, double amount, DateTime date)
        {
            string delete ="DELETE from statement WHERE source = @source amount = @amount date = @date type = INCOME";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
        }


        public static void addExpenseEntry(string source, double amount, DateTime date, string type, int uid)
        {
            OpenConnection();
            string insert = "INSERT INTO statement(source,amount,date,type,user_id) VALUES(@source,@amount,@date,@type,@uid)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);

            qCmd.Parameters.AddWithValue("@source", source);
            qCmd.Parameters.AddWithValue("@amount", amount);
            qCmd.Parameters.AddWithValue("@date", date);
            qCmd.Parameters.AddWithValue("@type", type);
            qCmd.Parameters.AddWithValue("@uid", uid);


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
        public static void GetIncomeStatements() {
            string get = "SELECT from statement WHERE type = 'INCOME';";
        }

        public static void GetExpenseStatements() { }

         
    }
    
}
    
