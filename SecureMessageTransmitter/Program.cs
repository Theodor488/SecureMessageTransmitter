using System;
using System.Security.Cryptography;
using System.Formats.Asn1;
using System.Text;

namespace SecureMessageTransmitter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KeyManager.GenerateRsaKeys(out string publicKey, out string privateKey);

            string secretmessage = "Hello there this is a secret message";
            Console.WriteLine($"Message: {secretmessage}");

            // 1. Encode the message into ASN.1
            byte[] asn1EncodedBytes = Asn1Encoder.EncodeMessageToAsn1(secretmessage);
            Console.WriteLine($"ASN.1 EncodedBytes: {BitConverter.ToString(asn1EncodedBytes)}");

            // 2. Encrypt the ASN.1 encoded message using RSA
            byte[] encryptedMessage = RsaEncoder.RsaEncrypt(asn1EncodedBytes, publicKey);
            Console.WriteLine($"RSA encryptedMessage: {BitConverter.ToString(encryptedMessage)}");

            // Simulate transmission of the encrypted message
            byte[] receivedEncryptedMessage = encryptedMessage;

            // 3. Decrypt the ASN.1 encoded message message back from RSA
            byte[] decryptedMessage = RsaEncoder.RsaDecrypt(receivedEncryptedMessage, privateKey);

            // 4. Decode message from ASN.1
            string decodedString = Asn1Encoder.DecodeMessageFromAsn1(decryptedMessage);
            Console.WriteLine($"String Decoded from ASN.1: {decodedString}");
        }
    }
}
