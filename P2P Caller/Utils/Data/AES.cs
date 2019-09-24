using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace P2P_Caller.Utils
{
    class AES
    {
        private AesCryptoServiceProvider myAes;

        public AES()
        {
            myAes = new AesCryptoServiceProvider();
            myAes.BlockSize = 128;
            myAes.KeySize = 128;
            myAes.IV = Encoding.UTF8.GetBytes("S0meInit_IVector");
            myAes.Key = Encoding.UTF8.GetBytes("ISp0koTnProjektx");
            myAes.Mode = CipherMode.CBC;
            myAes.Padding = PaddingMode.PKCS7;
        }
        // wynik tej funkcji należy zapisać binarnie do pliku
        /*byte[] encrypted = aes.Encrypt(someJSON)
        using (FileStream fs = new FileStream("file.file", FileMode.OpenOrCreate))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write(encrypted);
                bw.Close();
            }
        }*/
        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted;
            ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
            return encrypted;
        }

        // a to funkcja jakby się chciało szyfrować strumień bajtów w rozmowie
        // wątpię aby była użyta
        public byte[] Encrypt(byte[] plainTextbyte)
        {
            byte[] encrypted;
            ICryptoTransform encryptor = myAes.CreateEncryptor(myAes.Key, myAes.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    csEncrypt.Write(plainTextbyte, 0, plainTextbyte.Length);
                }
                encrypted = msEncrypt.ToArray();
            }
            return encrypted;
        }

        // do funkcji podajemy binarnie odczytane wartości z pliku
        // byte[] fileEncrypted = File.ReadAllBytes("file.file")
        // string jsonread = aes.Decrypt(fileEncrypted)
        public string Decrypt(byte[] cipherText)
        {
            string plaintext;
            ICryptoTransform decryptor = myAes.CreateDecryptor(myAes.Key, myAes.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
    }
}
