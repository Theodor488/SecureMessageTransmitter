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
            // What are different encoding rules beyond DER?
            AsnWriter writer = new AsnWriter(AsnEncodingRules.DER);

            // What are tag numbers? do they vary, Does a system that only
            // reads ASN1 messages need to understand all of the tag numbers?
            writer.WriteCharacterString(UniversalTagNumber.IA5String, message);
            byte[] encodedData = writer.Encode();

            return encodedData;
        }

        public static string DecodeMessageFromAsn1(byte[] encodedData)
        {
            AsnReader reader = new AsnReader(encodedData, AsnEncodingRules.DER);

            return reader.ReadCharacterString(UniversalTagNumber.IA5String);
        }

        public static void ReadCurrentAsn1Tag(byte[] encodedData)
        {
            AsnReader reader = new AsnReader(encodedData, AsnEncodingRules.DER);
            Asn1Tag tag = reader.PeekTag();
            Console.WriteLine($"Tag Class: {tag.TagClass}, Tag Value: {tag.TagValue}");
        }
    }
}