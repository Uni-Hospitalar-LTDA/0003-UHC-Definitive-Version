using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Integra.Configuration
{
    /// <summary>
    /// Classe responsável por criptografia e descriptografia de dados.
    /// </summary>
    public static class Criptografia
    {
        private const int Keysize = 256; // Tamanho da chave em bits
        private const int DerivationIterations = 1000; // Iterações para derivar a chave
        private const string MasterKey = "Integra_Key#"; // Chave mestre padrão

        /// <summary>
        /// Criptografa um texto com base em uma chave fornecida.
        /// </summary>
        /// <param name="texto">Texto a ser criptografado.</param>
        /// <returns>Texto criptografado.</returns>
        public static string Criptografar(string texto)
        {
            return Encrypt(texto, MasterKey);
        }

        /// <summary>
        /// Descriptografa um texto criptografado com base em uma chave fornecida.
        /// </summary>
        /// <param name="texto">Texto criptografado.</param>
        /// <returns>Texto descriptografado.</returns>
        public static string Descriptografar(string texto)
        {
            return Decrypt(texto, MasterKey);
        }

        /// <summary>
        /// Criptografa um texto com base em uma chave.
        /// </summary>
        private static string Encrypt(string plainText, string passPhrase)
        {
            var saltBytes = Generate256BitsOfRandomEntropy();
            var ivBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);

                using (var symmetricKey = new RijndaelManaged
                {
                    BlockSize = 256,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivBytes))
                using (var memoryStream = new MemoryStream())
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();

                    // Concatena salt, IV e texto cifrado
                    var cipherTextBytes = saltBytes.Concat(ivBytes).Concat(memoryStream.ToArray()).ToArray();
                    return Convert.ToBase64String(cipherTextBytes);
                }
            }
        }

        /// <summary>
        /// Descriptografa um texto criptografado.
        /// </summary>
        private static string Decrypt(string cipherText, string passPhrase)
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            var saltBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);

                using (var symmetricKey = new RijndaelManaged
                {
                    BlockSize = 256,
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivBytes))
                using (var memoryStream = new MemoryStream(cipherTextBytes))
                using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                using (var streamReader = new StreamReader(cryptoStream, Encoding.UTF8))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Gera 256 bits de entropia aleatória.
        /// </summary>
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
    }
}
