using System;
using System.IO;
using System.Security.Cryptography;

namespace PetStar.App_Data
{
    public static class EncryptionHelper
    {
        public static string Encrypt(string text)
        {
            byte[] encrypted;
            using (var rijndaelManaged = new RijndaelManaged())
            {
                ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(rijndaelManaged.Key, rijndaelManaged.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(text);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }
    }
}