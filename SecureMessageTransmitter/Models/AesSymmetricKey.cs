using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter.Models
{
    public class AesSymmetricKey
    {
        public AesSymmetricKey(byte[] iv, byte[] key)
        {
            Key = key;
            IV = iv;
        }

        public byte[] Key { get; private set; }
        public byte[] IV { get; private set; }
    }
}
