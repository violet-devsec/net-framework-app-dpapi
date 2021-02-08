using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace EncryptSecrets
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Text to encrypt: ");
            string plainText = Console.ReadLine();

            Console.WriteLine("Enter your name as entropy value: ");
            string entropyText = Console.ReadLine();

            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            byte[] entropyBytes = Encoding.Unicode.GetBytes(entropyText);

            byte[] encryptedBytes = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);

            WriteTextToFile(encryptedBytes);

            Console.WriteLine("Hit 'Enter' to stop");
            Console.ReadLine();
        }

        private static void WriteTextToFile(byte[] bytes)
        {

            string myDocs = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string path = myDocs + @"\Secret.txt";

            string EncBase64Value = Convert.ToBase64String(bytes);

            Console.WriteLine("Bse64 decoded encrypted value: "+EncBase64Value);

            // Delete the file if it exists
            if (File.Exists(path))
                File.Delete(path);

            File.WriteAllText(path, EncBase64Value);
        }
    }
}
