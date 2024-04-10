using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public class AesEncryptor
    {
        public static byte[] AesEncrypt(byte[] encodedData, byte[] aesKey, byte[] aesIV)
        {
            byte[] encrypted;

            // AesManaged is a class with the AES encryption and decryption functionality
            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aesKey, aesIV);

                // MemoryStream holds the encrypted data.
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(encodedData, 0, encodedData.Length); // Write byte array directly
                        cs.FlushFinalBlock(); // Ensure all data is written to the memory stream
                    }
                    return ms.ToArray();
                }
            }
        }

        public static byte[] AesDecrypt(byte[] cipherText, byte[] Key, byte[] IV)
        {
            byte[] decrypted;

            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);

                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (MemoryStream msResult = new MemoryStream())
                        {
                            cs.CopyTo(msResult);
                            return  msResult.ToArray();
                        }
                    }
                }
            }
        }
    }
}
