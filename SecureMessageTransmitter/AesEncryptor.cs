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

            using (AesManaged aes = new AesManaged())
            {
                ICryptoTransform encryptor = aes.CreateEncryptor(aesKey, aesIV);

                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption
                    // and encrypts and decrypts data from any given stream. 
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(encodedData);
                        encrypted = ms.ToArray();
                    }
                }

                return encrypted;
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
                            decrypted = msResult.ToArray();
                        }
                    }
                }
            }

            return decrypted;
        }
    }
}
