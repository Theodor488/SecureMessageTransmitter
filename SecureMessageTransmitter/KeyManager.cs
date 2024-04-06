using SecureMessageTransmitter.Models;
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
        // Why use "out" variables rather than create an simple class to contain public/private key?
        public static KeyPair GenerateRsaKeys()
        {
            // Creates RSA key pair with 2048 bits
            using (RSA rsa = RSA.Create(2048)) 
            {
                return new KeyPair(Convert.ToBase64String(rsa.ExportSubjectPublicKeyInfo()), 
                                    Convert.ToBase64String(rsa.ExportPkcs8PrivateKey()));   
            }
        }
    }
}
