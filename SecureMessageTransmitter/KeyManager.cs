using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public static class KeyManager
    {
        public static RsaKeyPair GenerateRsaKeys()
        {
            // Creates RSA key pair with 2048 bits
            using (RSA rsa = RSA.Create(2048)) 
            {
                string publicKey = Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo());
                string privateKey = Convert.ToBase64String(rsa.ExportPkcs8PrivateKey());

                return new RsaKeyPair(publicKey, privateKey);
            }
        }
    }
}
