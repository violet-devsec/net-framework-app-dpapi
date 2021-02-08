using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace DecryptSecrets
{
    public static class Crypto
    {
        public static string DecryptString(string secret)
        {
            //string entropyText = "entropy";

            //byte[] entropyBytes = Encoding.Unicode.GetBytes(entropyText);

            byte[] plainBytes = ProtectedData.Unprotect(Convert.FromBase64String(secret), null, DataProtectionScope.CurrentUser);

            string plainText = Encoding.Unicode.GetString(plainBytes);

            return plainText;
        }
    }
}