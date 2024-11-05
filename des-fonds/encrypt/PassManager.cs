//Plan is to encrypt password using a sha-256 hash function, then when user tries to login in we call this function, converting their input into the
//hashed password we have stored on our side
//one issue of this is that we can never see the plaintext passwords of our users


using System;
using System.Text
using System.Security.Cryptography;


namespace des_fonds.encrypt

public class sha
{

public static string Hash(string password)

{

    using (SHA256 sha256 = SHA256.Create());{
    byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes())

    StringBuilder Hashed = new StringBuilder();


    for(int i = 0; i<bytes.Length;i++)
    {
    Hashed.append(bytes[i].ToString("x2"));
    }

    return Hashed ToString();
    }


}
}
//afterwards store hash password and do a simple if hashedpass == sha(input) return true
public bool CheckHash(){

    if(pass == Hash(input)){return true;}
}
