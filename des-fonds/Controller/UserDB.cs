namespace des_fonds.Controller;

public class UserDB
{
    
    
    

    private string userTable = "CREATE TABLE users(ID PRIMARY KEY, UName VARCHAR(100), PWD VARCHAR(100))";
    
    public void addEntry(int id, string uName, string pwd)
    {
        string insert = "INSERT INTO users(ID, UName, PWD) VALUES(id, uName, pwd)";
        
    }

    public void removeEntry(int id, string uName, string pwd)
    {
        string delete = "DELETE FROM users WHere ID = @id)";
    }
}