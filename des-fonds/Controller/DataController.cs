using des_fonds.Finances;
using des_fonds.Mail;
using des_fonds.Users;
using MySql.Data;
using MySql.Data.MySqlClient;

using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
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
            Close();
        }

        public static void CreateStatementTable()
        {
            OpenConnection();

            string stab = "CREATE TABLE statements" +
                "(ID  int PRIMARY KEY AUTO_INCREMENT," +
                "source varchar(100) NOT NULL," +
                "amount varchar(100)," +
                "date datetime," +
                "type ENUM('INCOME','EXPENSE') NOT NULL," +
                 "user_id INT NOT NULL," +
                "FOREIGN KEY (user_id) REFERENCES users(ID))";
            MySqlCommand qcmd = new MySqlCommand(stab, connection);
            qcmd.ExecuteNonQuery();
            Close();
        }

        public static void CreateMessageTable()
        {

            OpenConnection();
            string create = "CREATE TABLE messages" +
            "(Sender varchar(100)," +
            "SenderID INT," +
            "Receiver varchar(100)," +
            "ReceiverID INT," +
            "Message varchar(100))";
            MySqlCommand qCmd = new MySqlCommand(create, connection);
            qCmd.ExecuteNonQuery();
            Close();

        }
        // public static void CreateHousehold(string HouseHoldName) 
        //{ OpenConnection();
        //  string create = "CREATE TABLE @household" +

        //   "(HouseHold_ID PRIMARY KEY NOT NULL," +
        // "user_id" +
        // "member_id;
        //household id  user_id, member_id

        //   "(User_ID INT NOT NULL," +
        // ;


        public static void CreateHouseHoldTable()
        {
            OpenConnection();
            string houseTable = "CREATE TABLE households" +
                "(ID int PRIMARY KEY AUTO_INCREMENT," +
                "user_id INT NOT NULL," +
                "mem1_id INT," +
                "mem2_id INT," +
                "mem3_id INT," +
                "mem4_id INT," +
                "mem5_id INT," +
                "mem6_id INT," +
                "bill_id INT," +
                "FOREIGN KEY (user_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem1_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem2_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem3_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem4_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem5_id) REFERENCES users(ID)," +
                "FOREIGN KEY (mem6_id) REFERENCES users(ID))";
            MySqlCommand cmd = new MySqlCommand(houseTable, connection);
            cmd.ExecuteNonQuery();
            Close();
        }
        public static void createHouseholdMemberTable()
        {
            string memberTab = "CREATE TABLE household_members " +
                "(house_id INT NOT NULL," +
                "user_id INT NOT NULL," +
                "FOREIGN KEY (house_id) REFERENCES households(id)," +
                "FOREIGN KEY (user_id) REFERENCES users(id))";
            using MySqlCommand cmd = new MySqlCommand(memberTab, connection);
            cmd.ExecuteNonQuery();
            

        }
        public static void InsertHouseholdHead(User user)
        {            
            string insertHouse = "INSERT INTO households " +
                "(user_id)" +
                "VALUES(@user_id)";
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(insertHouse, connection);

            //adding parameters
            cmd.Parameters.AddWithValue("@user_id", user.Id);
            cmd.ExecuteNonQuery();
            Close();
        }
        public static void InsertHouseholdMember(Message message)
        {
            OpenConnection();
                Household house = GetHousehold(message.PartyA);
                int membercount = house.Members.Count;
                string query = "";

                if ((membercount + 1) < 6)
                {

                    query = $"INSERT INTO household_members " +
                        "(house_id, user_id)" +
                        "VALUES(@house_id, @user_id)";

                    
                }
                else
                {
                    throw new Exception("Members List is Full");
                }

                using MySqlCommand cmd = new MySqlCommand(query, connection);
            
                cmd.Parameters.AddWithValue("@house_id", house.Id);
                cmd.Parameters.AddWithValue("@user_id", message.PartyB.Id);
                cmd.ExecuteNonQuery();
                Close();

  
        }




        public static void CreateBillTable()
        {
            OpenConnection();
            string billTable = "CREATE TABLE bills" +
                "(ID INT PRIMARY KEY AUTO_INCREMENT," +
                "house_id INT NOT NULL," +
                "name VARCHAR(25) NOT NULL," +
                "amount INT NOT NULL," +
                "due_date DATE NOT NULL," +
                "FOREIGN KEY (house_id) REFERENCES households(user_id))";
            MySqlCommand cmd = new MySqlCommand(billTable, connection);
            cmd.ExecuteNonQuery();
        }

        public static void InsertBill(User user, string billName, double amount, DateTime date)
        {
            OpenConnection();
            string insertBill = "INSERT INTO bills" +
                "(house_id, name, amount, due_date)" +
                "VALUES(@house_id, @name, @amount, @date)";
            using MySqlCommand cmd = new MySqlCommand(insertBill, connection);
            Household house = GetHousehold(user);
            cmd.Parameters.AddWithValue("@house_id", house.Id);
            cmd.Parameters.AddWithValue("@name", billName);
            cmd.Parameters.AddWithValue("@amount", amount);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.ExecuteNonQuery();
            Close();

        }
        public static Household GetHousehold(User user)
        {
            OpenConnection();
            string gethouse = "SELECT * FROM households " +
                "WHERE user_id = @user_id";
            using MySqlCommand cmd = new MySqlCommand(gethouse, connection);
            cmd.Parameters.AddWithValue("@user_id", user.Id);
            using MySqlDataReader reader = cmd.ExecuteReader();

            try
            {
                int id = 0;
                int headId = 0;
                List<User> members = new List<User>();
                if (reader.Read())
                {

                    id = reader.GetInt32(1);
                    headId = reader.GetInt32(0);

                    for (int i = 2; i < 8; i++)
                    {
                        if (reader.IsDBNull(i))
                        {
                            break;
                        }
                        else
                        {
                            int memberid = reader.GetInt32(i);
                            User member = GetUserEntry(memberid);
                            members.Add(member);
                        }
                    }
                    if (!reader.IsDBNull(8))
                    {
                        int bill_id = reader.GetInt32(8);
                    }

                }

            
                return new Household(id, headId, members);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void DeleteUser(int id, string uName, string pwd)
        {
            OpenConnection();
            string delete = "DELETE FROM users WHERE ID = @id)";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
            qCmd.ExecuteNonQuery();
        }
        public static void UpdateUserEntry(int id, string uName, string fname, string Lname)
        {
            OpenConnection();
            string update = "UPDATE users SET UName = @uName, First_Name = @fname, Last_Name = @lname WHERE ID = @id";
            MySqlCommand qCmd = new MySqlCommand(update, connection);

            qCmd.Parameters.AddWithValue("@id", id);
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
            using MySqlCommand command = new MySqlCommand(select, connection);
            command.Parameters.AddWithValue("@uName", uName);


            using MySqlDataReader reader = command.ExecuteReader();
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
        public static User GetUserEntry(int uId)
        {

            OpenConnection();
            string select = "SELECT u.ID, u.First_Name, u.Last_Name, u.Age, u.UName, u.PWD," +
                " a.street, a.postcode, a.city, a.country" +
                " FROM users u" +
                " LEFT JOIN addresses a ON u.ID = a.user_id" +
                " WHERE ID = @uid";
            using (MySqlCommand command = new MySqlCommand(select, connection))
            {
                command.Parameters.AddWithValue("@uid", uId);


                using (MySqlDataReader reader = command.ExecuteReader())
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

        public static void addIncomeEntry(string source, double amount, DateTime date, string type, int uid)
        {//other way to do this is by passing income class and using getter in insert statement
            //Income income
            //income.source
            //income.amount
            //income.date
            OpenConnection();
            string insert = "INSERT INTO statements(source,amount,date,type,user_id) VALUES(@source,@amount,@date,@type,@uid)";
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
            string delete = "DELETE from statements WHERE source = @source amount = @amount date = @date type = INCOME";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
        }

        public static void removeExpenseEntry(string source, double expense, DateTime date)
        {
            string delete = "DELETE from statements WHERE source = @source amount = @expense date = @date type = EXPENSE";
            MySqlCommand qCmd = new MySqlCommand(delete, connection);
        }

        public static void addExpenseEntry(string source, double amount, DateTime date, string type, int uid)
        {
            OpenConnection();
            string insert = "INSERT INTO statements(source,amount,date,type,user_id) VALUES(@source,@amount,@date,@type,@uid)";
            MySqlCommand qCmd = new MySqlCommand(insert, connection);

            qCmd.Parameters.AddWithValue("@source", source);
            qCmd.Parameters.AddWithValue("@amount", amount);
            qCmd.Parameters.AddWithValue("@date", date);
            qCmd.Parameters.AddWithValue("@type", type);
            qCmd.Parameters.AddWithValue("@uid", uid);


            qCmd.ExecuteNonQuery();
        }

  

        public static void GetStatementTable(DateTime date)
        {
            string get = "SELECT from statements WHERE date = @date";
            MySqlCommand qCmd = new MySqlCommand(get, connection);
            qCmd.ExecuteNonQuery();
        }
        public static void GetStatements(int id)
        {
            string get = "SELECT from statements WHERE user_id = '@id';";
            MySqlCommand qCmd = new MySqlCommand(get, connection);
            qCmd.ExecuteNonQuery();
        }
        public static finalstatement GetIncomeStatements(int id)
        {
            OpenConnection();
            string get = "SELECT source, amount, user_id FROM statements WHERE type = 'INCOME' AND user_id = @id;";
            using (MySqlCommand qCmd = new MySqlCommand(get, connection)) 
            {
                qCmd.Parameters.AddWithValue("@id", id);
                int totalIncome = 0;
                List<int> incomes = new List<int>();
                List<string> sources = new List<string>();

                using (MySqlDataReader reader = qCmd.ExecuteReader()) 
                {
                    while (reader.Read())
                    {
                        
              
                            string source = reader.GetString("source");
                            int amount = reader.GetInt32("amount");
                            //DateTime date = reader.GetDateTime("date");
                            int uID = reader.GetInt32("user_id");

                            
                        incomes.Add(amount);
                        sources.Add(source);
                        totalIncome += amount;
                        
                        

                    }
                    return new finalstatement(incomes, totalIncome,sources);


                    Close();
                        
                    
                }
            

            }   
        }

        public static finalstatement GetExpenseStatements(int id) 
        {
            OpenConnection();
            string get = "SELECT source, amount, user_id FROM statements WHERE type = 'EXPENSE' AND user_id = @id;";
            using (MySqlCommand qCmd = new MySqlCommand(get, connection))
            {
                qCmd.Parameters.AddWithValue("@id", id);

                int totalExpense = 0;
                List<int> expenses = new List<int>();
                List<string> sources = new List<string>();


                using (MySqlDataReader reader = qCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {


                        string source = reader.GetString("source");
                        int amount = reader.GetInt32("amount");
                        //DateTime date = reader.GetDateTime("date");
                        int uID = reader.GetInt32("user_id");

                       
                        expenses.Add(amount);
                        sources.Add(source);
                        totalExpense += amount;


                    }
                    return new finalstatement(expenses, totalExpense,sources);


                    Close();
                        
                    
                }


            }



        }


        public static void AddMessageEntry(string sender, int senid, string receiver, int recid, string message)
        {
            OpenConnection();
            string insert = "INSERT INTO messages (Sender, SenderID, Receiver, ReceiverID, Message) " +
                        "VALUES (@sender, @senid, @receiver, @recid, @message)";

            using (MySqlCommand qCmd = new MySqlCommand(insert, connection))
            {
                qCmd.Parameters.AddWithValue("@sender", sender);
                qCmd.Parameters.AddWithValue("@senid", senid);
                qCmd.Parameters.AddWithValue("@receiver", receiver);
                qCmd.Parameters.AddWithValue("@recid", recid);
                qCmd.Parameters.AddWithValue("@message", message);

                qCmd.ExecuteNonQuery();
            }
            Close();
        }
      

        public static Message GetMessage(int recId)
        {
            OpenConnection();
            string get = "SELECT Sender, SenderID,Receiver,ReceiverID,Message from messages WHERE ReceiverID = @recId";

            MySqlCommand qCmd = new MySqlCommand(get, connection);

            qCmd.Parameters.AddWithValue("@recID", recId);
         
            using (MySqlDataReader reader = qCmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    string sender = reader.GetString("Sender");
                    int senderID = reader.GetInt32("SenderID");
                    string Receiver = reader.GetString("Receiver");
                    int ReceiverID = reader.GetInt32("ReceiverID");
                    string message = reader.GetString("Message");
                    User partyA = GetUserEntry(sender);
                    User partyB = GetUserEntry(Receiver);
                   
                    Close();
                    
                    return new Message(DateTime.Now,partyA,partyB,message);
                    

                }
                else {
                    Close();
                    throw new Exception("issue");
                         }

                
                 
                

            }

        }
        public static List<Message> GetMessageList(int recId)
        {
            OpenConnection();
            string get = "SELECT Sender, SenderID,Receiver,ReceiverID,Message from messages WHERE ReceiverID = @recId";

            MySqlCommand qCmd = new MySqlCommand(get, connection);

            List<Message> messages = new List<Message>();

            qCmd.Parameters.AddWithValue("@recID", recId);

            using (MySqlDataReader reader = qCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                   
                    string sender = reader.GetString("Sender");
                    int senderID = reader.GetInt32("SenderID");
                    string Receiver = reader.GetString("Receiver");
                    int ReceiverID = reader.GetInt32("ReceiverID");
                    string message = reader.GetString("Message");
                    User partyA = GetUserEntry(sender);
                    User partyB = GetUserEntry(Receiver);

                    Close();

                    messages.Add(new Message(DateTime.Now,partyA,partyB,message));


                }
                return messages;
               





            }

        }
    }
    
}
    
