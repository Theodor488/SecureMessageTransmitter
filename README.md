# Secure Message Transmitter

The Secure Message Transmitter takes a string message as an input and does the following to encode / encrypt it:

- **Step 1. Encodes the message into ASN.1.**
     - This process converts the message into hexadecimal format using the DER ASN.1 Encoding Rule. DER (Distinguished Encoding Rules) is similar to another ASN.1 encoding rule called "BER" (Basic Encoding Rules), but converts the data into a canonical form. Meaning that the data could have more than one possible representation in BER, but with DER the string was converted to a hex that can only have one possible representation.
  
- **Step 2. Encrypt the ASN.1 encoded message using RSA.**
    - This process takes the ASN.1 encoded message and encrypts it using RSA. Two keys (public and private) are generated. The public key is used to RSA encrypt the ASN.1 encoded bytes, making it safe for transit from the sender to the receiver. This prevents attackers from intercepting the message and reading its contents. RSA uses an algorithm which selects 2 prime numbers (p,q), multiplies them together (n=p*q), calculates the totient (t=(p-1)*(q-1)), selects a public key that is a prime number less than t and not a fator of t, and finally determines the private key that meets the condition (e*d) mod t = 1.
  
- **Step 3. Decrypt the ASN/1 encoded message back from RSA**
    - In a real life situation this is when the recpient would have received the message. This step uses the privateKey to RSA decrypt the RSA encoded message.

 - **Step 4. Decode message from ASN.1**
    - After ASN decrypting the message, the message is still in a hexadecimal array of bytes in ASN.1 form. Decoding the message from ASN.1 will output the original message.
