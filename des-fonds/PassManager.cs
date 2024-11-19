//hashed password we have stored on our side
//one issue of this is that we can never see the plaintext passwords of our users


using System;
using System.Text;
using System.Security.Cryptography;


namespace des_fonds.encrypt;

public class PassManager
{

    public static string HashPassword(string password)
    {
        using SHA256 sha256 = SHA256.Create();
        //compute hash from password
        byte[] hashbytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        //convert byte array to string
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hashbytes.Length; i++)
        {
            sb.Append(hashbytes[i].ToString("X2"));
        }
        return sb.ToString();
    }
    public static bool CompareTo(string storedPassword, string password)
    {
        string checkPassword = HashPassword(password);
        return storedPassword.Equals(checkPassword);
    }

}
