using System;
using System.Security.Cryptography;
using System.Formats.Asn1;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using SecureMessageTransmitter.Models;

namespace SecureMessageTransmitter
{
    internal class Program
    {
        // This a good approach to demonstrate the code. An UNIT test project is also important.
        // Also, take a stab at a JAVA project that performs the same functions.
        static void Main(string[] args)
        {
            KeyPair rsaKeyPair = KeyManager.GenerateRsaKeys();

            string secretmessage = "Hello there this is a secret message";
            Console.WriteLine($"Message: {secretmessage}");

            // 1. Encode the message into ASN.1
            byte[] asn1EncodedBytes = Asn1Encoder.EncodeMessageToAsn1(secretmessage);
            Console.WriteLine($"ASN.1 EncodedBytes: {BitConverter.ToString(asn1EncodedBytes)}");

            // 2. Encrypt the ASN.1 encoded message using RSA
            byte[] encryptedMessage = RsaEncoder.RsaEncrypt(asn1EncodedBytes, rsaKeyPair.PublicKey);
            Console.WriteLine($"RSA encryptedMessage: {BitConverter.ToString(encryptedMessage)}");
            
            // Simulate transmission of the encrypted message
            byte[] receivedEncryptedMessage = encryptedMessage;

            // 3. Decrypt the ASN.1 encoded message message back from RSA
            byte[] decryptedMessage = RsaEncoder.RsaDecrypt(receivedEncryptedMessage, rsaKeyPair.PrivateKey);

            // 4. Decode message from ASN.1
            string decodedString = Asn1Encoder.DecodeMessageFromAsn1(decryptedMessage);
            Console.WriteLine($"String Decoded from ASN.1: {decodedString}");
        }
    }
}
