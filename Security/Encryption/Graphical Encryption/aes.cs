using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
 
public static class AESEncryption
    {
        // Usage example: string encrypt = AESEncryption.Encrypt("apple", "12345", AESEncryption.GenerateIV());
 
        #region Encryption
 
        public static string Encrypt(string PlainText, string Password, string IV = "bjKG79@vdGSZmX**", string Salt = "test", string HashAlg = "SHA1",
            int PwRounds = 2, int KeySize = 256)
        {
            if (String.IsNullOrEmpty(PlainText)) return "";
 
            byte[] IVBytes = Encoding.ASCII.GetBytes(IV);
            // Insecure static IV! GenerateIV() string recommended when calling.
 
            byte[] SaltBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] PlainTextBytes = Encoding.UTF8.GetBytes(PlainText);
            PasswordDeriveBytes DerivedPass = new PasswordDeriveBytes(Password, SaltBytes, HashAlg, PwRounds);
            byte[] KeyBytes = DerivedPass.GetBytes(KeySize / 8);
            RijndaelManaged SymmKey = new RijndaelManaged();
            SymmKey.Mode = CipherMode.CFB;
            // CipherMode was switched from default (CBC). Choice of the ciphermode not yet implemented.
 
            byte[] FinalCipherBytes = null;
 
            using (ICryptoTransform Encryptor = SymmKey.CreateEncryptor(KeyBytes, IVBytes))
            {
                using (MemoryStream MemStream = new MemoryStream())
                {
                    using (CryptoStream CStream = new CryptoStream(MemStream, Encryptor, CryptoStreamMode.Write))
                    {
                        CStream.Write(PlainTextBytes, 0, PlainTextBytes.Length);
                        CStream.FlushFinalBlock();
                        FinalCipherBytes = MemStream.ToArray();
                        MemStream.Close();
                        CStream.Close();
                    }
                }
            }
 
            SymmKey.Clear();
            return Convert.ToBase64String(FinalCipherBytes);
        }
        #endregion
 
        #region Random IV generation
 
        public static string GenerateIV()
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 16; i++)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        #endregion
 
        #region Decryption
 
        public static string Decrypt(string CryptedText, string Password, string IV = "bjKG79@vdGSZmX**", string Salt = "test", string HashAlg = "SHA1",
            int pwRounds = 2, int KeySize = 256)
        {
            if (String.IsNullOrEmpty(CryptedText)) return "";
 
            byte[] IVBytes = Encoding.ASCII.GetBytes(IV);
            byte[] SaltBytes = Encoding.ASCII.GetBytes(Salt);
            byte[] CryptBytes = Convert.FromBase64String(CryptedText);
 
            PasswordDeriveBytes DerivedPass = new PasswordDeriveBytes(Password, SaltBytes, HashAlg, pwRounds);
            byte[] KeyBytes = DerivedPass.GetBytes(KeySize / 8);
            RijndaelManaged SymmKey = new RijndaelManaged();
            SymmKey.Mode = CipherMode.CFB;
            // Todo: add cipher mode option
 
            byte[] PlainBytes = new byte[CryptBytes.Length];
            int ByteCount = 0;
            using (ICryptoTransform Decryptor = SymmKey.CreateDecryptor(KeyBytes, IVBytes))
            {
                using (MemoryStream MemStream = new MemoryStream(CryptBytes))
                {
                    using (CryptoStream CStream = new CryptoStream(MemStream, Decryptor, CryptoStreamMode.Read))
                    {
                        ByteCount = CStream.Read(PlainBytes, 0, PlainBytes.Length);
                        MemStream.Close();
                        CStream.Close();
                    }
                }
            }
            SymmKey.Clear();
            return Encoding.UTF8.GetString(PlainBytes, 0, ByteCount);
        }
        #endregion
    }
