using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureMessageTransmitter
{
    public static class Asn1Encoder
    {
        public static byte[] EncodeMessageToAsn1(string message)
        {
            AsnWriter writer = new AsnWriter(AsnEncodingRules.DER);
            writer.WriteCharacterString(UniversalTagNumber.IA5String, message);
            return writer.Encode();
        }

        public static string DecodeMessageFromAsn1(byte[] encodedData)
        {
            AsnReader reader = new AsnReader(encodedData, AsnEncodingRules.DER);
            return reader.ReadCharacterString(UniversalTagNumber.IA5String);
        }
    }
}