using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public class RsaEncoder
    {
        // Consider adding methods that do shared key encyrption and decryption.

        public static byte[] RsaEncrypt(byte[] encodedData, string publicKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(publicKey), out _);

                // Encrypt the data
                return rsa.Encrypt(encodedData, RSAEncryptionPadding.OaepSHA256);
            }
        }

        public static byte[] RsaDecrypt(byte[] data, string privateKey)
        {
            using (var rsa = RSA.Create())
            {
                rsa.ImportPkcs8PrivateKey(Convert.FromBase64String(privateKey), out _);

                // Decrypt the data
                return rsa.Decrypt(data, RSAEncryptionPadding.OaepSHA256);
            }
        }
    }
}