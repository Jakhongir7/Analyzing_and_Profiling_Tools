using System.Security.Cryptography;

namespace Analyzing_and_Profiling_Tools
{
    public class Program
    {
        static void Main(string[] args)
        {
            string password = "SomePassword";
            byte[] salt = new byte[16];

            string hashedPassword = GeneratePasswordHashUsingSalt(password, salt);

            Console.WriteLine("Hashed Password:" + hashedPassword);
        }

        public static string GeneratePasswordHashUsingSalt(string passwordText, byte[] salt)
        {
            var iterate = 10000;
            var pbkdf2 = new Rfc2898DeriveBytes(passwordText, salt, iterate);
            byte[] hash = pbkdf2.GetBytes(20);

            // Combine salt and hash into a single byte array
            byte[] hashBytes = new byte[salt.Length + hash.Length];

            // Replaced the Array.Copy calls with Buffer.BlockCopy, which is generally more efficient for copying large byte arrays.
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}