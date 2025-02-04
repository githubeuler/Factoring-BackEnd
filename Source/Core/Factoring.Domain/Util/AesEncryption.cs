using System.Security.Cryptography;
using System.Text;

namespace Factoring.Domain.Util
{
    public class AesEncryption
    {
        // Método para encriptar
        public static string Encrypt(string plainText, string key, string fixedIV)
        {
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(fixedIV))
                throw new ArgumentNullException(nameof(fixedIV));

            // Convertir la clave y el IV a bytes
            var keyBytes = new byte[32];
            Encoding.UTF8.GetBytes(key.PadRight(keyBytes.Length)).CopyTo(keyBytes, 0);
            var ivBytes = Encoding.UTF8.GetBytes(fixedIV.PadRight(16).Substring(0, 16)); // IV debe ser de 16 bytes

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (var writer = new StreamWriter(cryptoStream))
                {
                    writer.Write(plainText);
                }
            }

            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cipherText, string key, string fixedIV)
        {
            if (string.IsNullOrEmpty(cipherText))
                throw new ArgumentNullException(nameof(cipherText));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if (string.IsNullOrEmpty(fixedIV))
                throw new ArgumentNullException(nameof(fixedIV));

            var keyBytes = new byte[32];
            Encoding.UTF8.GetBytes(key.PadRight(keyBytes.Length)).CopyTo(keyBytes, 0);
            var ivBytes = Encoding.UTF8.GetBytes(fixedIV.PadRight(16).Substring(0, 16));

            var fullCipher = Convert.FromBase64String(cipherText);

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream(fullCipher);
            using var cryptoStream = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
        public static string GenerateSecurePassword(int length = 8)
        {
            if (length < 8)
                throw new ArgumentException("La contraseña debe tener al menos 8 caracteres.", nameof(length));

            const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+<>?";

            // Asegurarse de incluir al menos un carácter de cada grupo
            var requiredChars = new[]
            {
            upperCase[RandomNumberGenerator.GetInt32(upperCase.Length)],
            lowerCase[RandomNumberGenerator.GetInt32(lowerCase.Length)],
            digits[RandomNumberGenerator.GetInt32(digits.Length)],
            //specialChars[RandomNumberGenerator.GetInt32(specialChars.Length)]
        };

            // Crear un conjunto de caracteres posibles
            var allChars = upperCase + lowerCase + digits + specialChars;

            // Generar los caracteres restantes
            var remainingChars = Enumerable.Range(0, length - requiredChars.Length)
                .Select(_ => allChars[RandomNumberGenerator.GetInt32(allChars.Length)])
                .ToArray();

            // Combinar y mezclar los caracteres
            var passwordChars = requiredChars.Concat(remainingChars).OrderBy(_ => RandomNumberGenerator.GetInt32(100)).ToArray();

            return new string(passwordChars);
        }
    }
}
