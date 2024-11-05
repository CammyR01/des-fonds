using System;
using System.Text;
using System.Security.Cryptography;

namespace des_fonds.encrypt
{
    public class Sha256Hasher
    {
        // Hash the given password using SHA-256
        public static string Hash(string password)
        {
            // Create a SHA256 instance
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the password
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Create a StringBuilder to collect the bytes
                StringBuilder hashed = new StringBuilder();

                // Loop through each byte of the hash and format it as a hexadecimal string
                for (int i = 0; i < bytes.Length; i++)
                {
                    // Append each byte in hexadecimal format
                    hashed.Append(bytes[i].ToString("x2"));
                }

                // Return the hashed password as a string
                return hashed.ToString();
            }
        }

        // Check if the hashed version of the input matches the stored hash
        public static bool CheckHash(string storedHash, string input)
        {
            // Compare the stored hash with the hash of the input
            return storedHash.Equals(Hash(input), StringComparison.OrdinalIgnoreCase);
        }
    }
}
