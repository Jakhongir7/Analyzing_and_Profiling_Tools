﻿using System.Security.Cryptography;

namespace YourNamespace
{
    public class Program
    {
        static void Main(string[] args)
        {
            string hashedPassword = GeneratePasswordHashUsingSalt("SomeText", new byte[16]);
            
            Console.WriteLine("Hashed Password:" + hashedPassword);
            Console.ReadKey();
        }

        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {

            var iterate = 10000;
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            var passwordHash = Convert.ToBase64String(hashBytes);

            return passwordHash;

        }
    }
}