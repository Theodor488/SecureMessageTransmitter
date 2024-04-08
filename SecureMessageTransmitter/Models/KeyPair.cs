using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter.Models
{
    public class KeyPair
    {
        public KeyPair(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }
    }
}
