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
            AesSymmetricKey aesSymmetricKey = KeyManager.GenerateAesKey();

            // AES Key / IV
            byte[] aesIV = aesSymmetricKey.IV;
            byte[] aesKey = aesSymmetricKey.Key;

            string secretmessage = "Hello there this is a secret message";
            Console.WriteLine($"Message: {secretmessage}");

            // 1. Encrypt the AES key using RSA
            byte[] encryptedAesKey = RsaEncoder.RsaEncrypt(aesKey, rsaKeyPair.PublicKey);
            Console.WriteLine($"RSA encrypted AES Symmetric key: {BitConverter.ToString(encryptedAesKey)}");

            // 2. Transfer (handshake) RSA-encrypted AES key from client to server (simulation)
            byte[] receivedEncryptedAesKey = encryptedAesKey;

            // 3. Decrypt the received RSA-encrypted AES key
            byte[] decryptedAesKey = RsaEncoder.RsaDecrypt(receivedEncryptedAesKey, rsaKeyPair.PrivateKey);

            // 4. Encode the secret message into ASN.1, preparing it for encryption
            byte[] asn1EncodedBytes = Asn1Encoder.EncodeMessageToAsn1(secretmessage);
            Console.WriteLine($"ASN.1 EncodedBytes: {BitConverter.ToString(asn1EncodedBytes)}");

            // 5. Encrypt the ASN.1 encoded secret message using the AES key
            byte[] aesEncryptedMessage = AesEncryptor.AesEncrypt(asn1EncodedBytes, aesKey, aesIV);
            Console.WriteLine($"AES encryptedMessage: {BitConverter.ToString(aesEncryptedMessage)}");

            // 6. Transfer (handshake) AES-encrypted ASN.1 encoded secret messsage from client to server (simulation)
            byte[] receivedEncryptedAesMessage = aesEncryptedMessage;

            // 7. Decrypt the message using the AES key
            byte[] decryptedMessage = AesEncryptor.AesDecrypt(receivedEncryptedAesMessage, aesKey, aesIV);

            // 8. Decode the message from ASN.1 to retrieve the original plaintext secret message
            string decodedMessage = Asn1Encoder.DecodeMessageFromAsn1(decryptedMessage);
            Console.WriteLine($"String Decoded from ASN.1: {decodedMessage}");
        }
    }
}
