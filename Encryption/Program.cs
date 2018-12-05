using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encryption
{
    
    class Program
    {
        static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using(MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using(StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public static void EncryptSomeText()
        {
            string original = "My data to encrypt";

            using(SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);

                Console.WriteLine("Byte Array : {0}", Encoding.Default.GetString(encrypted));

                Console.WriteLine("Original : {0}", original);
                Console.WriteLine("Round Trip : {0}", roundtrip);
            }
        }

        public static void RSACryptoDemo()
        {
            //asymmetric keys:
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);

            Console.WriteLine(publicKeyXML);
            Console.WriteLine("****************");
            Console.WriteLine(privateKeyXML);

            //**********

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Super secret shite");

            Console.WriteLine("dataToEncrypt : {0}", Encoding.Default.GetString(dataToEncrypt));

            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKeyXML);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
                Console.WriteLine("encryptedData : {0}", Encoding.Default.GetString(encryptedData));
            }

            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKeyXML);
                decryptedData = RSA.Decrypt(encryptedData, false);
                Console.WriteLine("decryptedData : {0}", Encoding.Default.GetString(decryptedData));
            }

            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine("decryptedString : {0}", decryptedString);

            //**************
            //key container
            string containerName = "MySecretContainer";
            CspParameters csp = new CspParameters() { KeyContainerName = containerName};
            using(RSACryptoServiceProvider rsa2 = new RSACryptoServiceProvider(csp))
            {
                encryptedData = rsa2.Encrypt(dataToEncrypt, false);
            }
        }

        static void Main(string[] args)
        {
            EncryptSomeText();
            RSACryptoDemo();
            Console.ReadKey();
        }
    }
}
