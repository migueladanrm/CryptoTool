using System;
using System.Security.Cryptography;
using System.Text;

namespace migueladanrm.CryptoTool
{
    /// <summary>
    /// Herramienta de encriptación.
    /// </summary>
    public static class Encryption
    {
        private static RijndaelManaged GetRijndaelManaged(string secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        private static byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged) => rijndaelManaged.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

        private static byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged) => rijndaelManaged.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);

        /// <summary>
        /// Encripta una cadena de texto plano utilizando una clave AES de 128 bits y un cifrado de bloque de cadena y retorna una cadena de texto codificada en Base64.
        /// </summary>
        /// <param name="plainText">Texto plano.</param>
        /// <param name="key">Clave secreta.</param>
        /// <returns>Cadena de texto codificada en Base64.</returns>
        public static string Encrypt(string plainText, string key) => Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(plainText), GetRijndaelManaged(key)));

        /// <summary>
        /// Desencripta una cadena codificada en Base64 utilizando una clave secreta (clave AES de 128 bits y un cifrado de bloque de cadena).
        /// </summary>
        /// <param name="encryptedText">Cadena de texto codificada en Base64.</param>
        /// <param name="key">Clave secreta.</param>
        /// <returns>Cadena de texto plano.</returns>
        public static string Decrypt(string encryptedText, string key) => Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(encryptedText), GetRijndaelManaged(key)));
    }
}