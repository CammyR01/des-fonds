using des_fonds.Controller;
using des_fonds.Finances;
using des_fonds.Users;

namespace des_fonds
{
    public class MoneyApp
    {
        //ATTRIBUTES
        private List<User> userList; //holds users of the app
        private static MoneyApp? app; //holds the instance of app
        
        //PROPERTIES
        public List<User> UserList { get => userList; set => userList = value; }
        public static MoneyApp Instance
        {
            get
            {
                if(app == null)
                {
                    app = new MoneyApp();
                    app.populate(); //populates the userlist with users includeing address and incomes and statements
                }
                return app;
            }
            set
            {
                app = value;
            }
        }
        /// <summary>
        /// constructs the money app instance and initializes the userslist
        /// </summary>
        public MoneyApp()
        {
            this.userList = new List<User>();            
        }
        /// <summary>
        /// Adds a user to the userlist.
        /// </summary>
        /// <param name="user">user to be added to the list</param>
        public void AddUser(User user)
        {
            UserList.Add(user);
            
        }
        
        /// <summary>
        /// removes a user from the list
        /// </summary>
        /// <param name="user">user to be removed from the list</param>
        public void RemoveUser(User user)
        {
            UserList.Remove(user);
        }
        /// <summary>
        /// used for testing, populates the users list with users including addresses
        /// adds statements to users
        /// </summary>
        private void populate()
        {
            //create users with addresses
            User user1 = new User("ash", encrypt.Sha256Hasher.Hash("pass"),"John","De",12, "1 Some Street", "g123bh","A City", "Somewhere");
            User user2 = new User("bob", encrypt.Sha256Hasher.Hash("pass2"), "Joe", "Di", 12, "2 Another Street", "g098cg", "Another City", "SomeWhere Else");
            User user3 = new User("suzan", encrypt.Sha256Hasher.Hash("pass3"), "Ti", "Last", 12, "3 Some Lane", "g389sd", "Greater City", "Somewhere");
            User user4 = new User("mel", encrypt.Sha256Hasher.Hash("pass4"), "John", "Doe", 12, "4 Another Lane", "g128jh", "City of Another", "SomeWhere too");

            //Create incomes for users
            Income in1 = new Income("Wage", 1234.99, new DateTime(2024, 10, 1));
            Income in2 = new Income("Side Hustle", 49.88, new DateTime(2024, 10, 2));
            Income in3 = new Income("Birthday Money", 100, new DateTime(2024, 10, 22));
            Income in4 = new Income("Wage", 1234.99, new DateTime(2024, 10, 1));
            Income in5 = new Income("Side Hustle", 49.88, new DateTime(2024, 10, 5));
            Income in6 = new Income("You Passed Go", 200, new DateTime(2024, 10, 2));
            Income in7 = new Income("bit coin", 1234.99, new DateTime(2024, 10, 8));
            Income in8 = new Income("some other job", 49.88, new DateTime(2024, 10, 9));
            Income in9 = new Income("side job", 100, new DateTime(2024, 10, 18));
            Income in10 = new Income("Wage", 1234.99, new DateTime(2024, 9, 1));
            Income in11 = new Income("Dealing", 120.00, new DateTime(2024, 9, 2));
            Income in12 = new Income("Birthday Money", 100.00, new DateTime(2024, 9, 22));
            Income in13 = new Income("only fans", 1234.99, new DateTime(2024, 9, 1));
            Income in14 = new Income("loan", 2000.00, new DateTime(2024, 9, 5));
            Income in15 = new Income("refund", 28.82, new DateTime(2024, 9, 2));
            Income in16 = new Income("grass cutting", 20.00, new DateTime(2024, 9, 8));
            Income in17 = new Income("car washing", 14.50, new DateTime(2024, 9, 9));
            Income in18 = new Income("side job", 408.93, new DateTime(2024, 9, 18));

            //Create expense
            Expense ex1 = new Expense("Rent", 1234.99, new DateTime(2024, 10, 1));
            Expense ex2 = new Expense("Shopping", 49.88, new DateTime(2024, 10, 2));
            Expense ex3 = new Expense("Broadband", 100, new DateTime(2024, 10, 22));
            Expense ex4 = new Expense("insurance", 1234.99, new DateTime(2024, 10, 1));
            Expense ex5 = new Expense("fuel", 49.88, new DateTime(2024, 10, 5));
            Expense ex6 = new Expense("Electricity", 200, new DateTime(2024, 10, 2));
            Expense ex7 = new Expense("Gas", 1234.99, new DateTime(2024, 10, 8));
            Expense ex8 = new Expense("Clothes", 49.88, new DateTime(2024, 10, 9));
            Expense ex9 = new Expense("x rated videos", 100, new DateTime(2024, 10, 18));
            Expense ex10 = new Expense("Rent", 1234.99, new DateTime(2024, 9, 1));
            Expense ex11 = new Expense("shopping", 120.00, new DateTime(2024, 9, 2));
            Expense ex12 = new Expense("mobile phone", 100.00, new DateTime(2024, 9, 22));
            Expense ex13 = new Expense("netflix", 1234.99, new DateTime(2024, 9, 1));
            Expense ex14 = new Expense("spotify", 2000.00, new DateTime(2024, 9, 5));
            Expense ex15 = new Expense("dinner", 28.82, new DateTime(2024, 9, 2));
            Expense ex16 = new Expense("games", 20.00, new DateTime(2024, 9, 8));
            Expense ex17 = new Expense("makeup", 14.50, new DateTime(2024, 9, 9));
            Expense ex18 = new Expense("haircut", 408.93, new DateTime(2024, 9, 18));

            //Create Bills
            Bill bill1 = new Bill("Electricity", Status.Paid, 150.75, new DateTime(2024, 10, 15));
            Bill bill2 = new Bill("Water", Status.Pending, 75.25, new DateTime(2024, 10, 16));
            Bill bill3 = new Bill("Gas", Status.Paid, 120.50, new DateTime(2024, 10, 17));
            Bill bill4 = new Bill("Internet", Status.Pending, 60.00, new DateTime(2024, 10, 20));
            Bill bill5 = new Bill("Phone", Status.Paid, 50.00, new DateTime(2024, 10, 21));
            Bill bill6 = new Bill("Insurance", Status.Pending, 200.00, new DateTime(2024, 10, 22));
            Bill bill7 = new Bill("Credit Card", Status.Paid, 500.00, new DateTime(2024, 10, 25));
            Bill bill8 = new Bill("Mortgage", Status.Pending, 1200.00, new DateTime(2024, 10, 1));
            Bill bill9 = new Bill("Streaming Service", Status.Paid, 12.99, new DateTime(2024, 10, 10));
            Bill bill10 = new Bill("Subscription", Status.Pending, 25.00, new DateTime(2024, 10, 5));


            //user1
            user1.AddStatement(in2);
            user1.AddStatement(ex6);
            user1.AddStatement(in7);
            user1.AddStatement(in3);
            user1.AddStatement(in6);
            user1.AddStatement(in2);
            user1.AddStatement(in14);
            user1.AddStatement(in13);
            user1.AddStatement(ex2);
            user1.AddStatement(in6);
            user1.AddStatement(ex7);
            user1.AddStatement(ex3);
            user1.AddStatement(ex6);
            user1.AddStatement(in12);
            user1.AddStatement(ex14);
            user1.AddStatement(ex13);
            //user 2
            user2.AddStatement(in1);
            user2.AddStatement(ex1);
            user2.AddStatement(in7);
            user2.AddStatement(in3);
            user2.AddStatement(in6);
            user2.AddStatement(ex18);
            user2.AddStatement(in14);
            user2.AddStatement(in13);
            user2.AddStatement(ex2);
            user2.AddStatement(ex6);
            user2.AddStatement(ex7);
            user2.AddStatement(ex3);
            user2.AddStatement(in6);
            user2.AddStatement(in12);
            user2.AddStatement(ex14);
            user2.AddStatement(in13);
            //user3
            user3.AddStatement(ex12);
            user3.AddStatement(in16);
            user3.AddStatement(ex17);
            user3.AddStatement(ex13);
            user3.AddStatement(ex16);
            user3.AddStatement(in12);
            user3.AddStatement(ex14);
            user3.AddStatement(ex13);
            user3.AddStatement(in12);
            user3.AddStatement(ex17);
            user3.AddStatement(in17);
            user3.AddStatement(in3);
            user3.AddStatement(ex6);
            user3.AddStatement(in12);
            user3.AddStatement(ex14);
            user3.AddStatement(ex13);
            //user4
            user1.AddStatement(in17);
            user1.AddStatement(in16);
            user1.AddStatement(in17);
            user1.AddStatement(in13);
            user1.AddStatement(in16);
            user1.AddStatement(in12);
            user1.AddStatement(in14);
            user1.AddStatement(in13);
            user1.AddStatement(ex12);
            user1.AddStatement(in16);
            user1.AddStatement(ex17);
            user1.AddStatement(ex13);
            user1.AddStatement(ex16);
            user1.AddStatement(in2);
            user1.AddStatement(ex4);
            user1.AddStatement(ex3);
            //add users to the list
            MoneyApp.Instance.AddUser(user1);
            MoneyApp.Instance.AddUser(user2);
            MoneyApp.Instance.AddUser(user3);
            MoneyApp.Instance.AddUser(user4);
        }
        
            



    }
}
