using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public class RsaKeyPair
    {
        public string PublicKey { get; }
        public string PrivateKey { get; }

        public RsaKeyPair(string publicKey, string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
