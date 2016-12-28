using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using ThouShallNotPass.Services.Extensions;

namespace ThouShallNotPass.Services
{
    public interface ICryptoService
    {
        Task<byte[]> Encrypt(string key, byte[] data);

        Task<byte[]> Decrypt(string key, byte[] data);
    }

    public class CryptoService : ICryptoService
    {
        private readonly byte[] _IV;

        public CryptoService()
        {
            _IV = ASCIIEncoding.ASCII.GetBytes("ThouShallNotPass");
        }

        public async Task<byte[]> Decrypt(string key, byte[] data)
        {
            byte[] result;
            using (var aes = Aes.Create())
            {
                aes.Key = key.Tosha256();
                aes.Padding = PaddingMode.Zeros;
                aes.IV = _IV;

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, decryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(data))
                    {
                        await plainStream.CopyToAsync(aesStream);
                    }

                    result = resultStream.ToArray();
                }
            }

            return result;
        }

        public async Task<byte[]> Encrypt(string key, byte[] data)
        {
            byte[] result;
            using (var aes = Aes.Create())
            {
                aes.Key = key.Tosha256();
                aes.Padding = PaddingMode.Zeros;
                aes.IV = _IV;

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var resultStream = new MemoryStream())
                {
                    using (var aesStream = new CryptoStream(resultStream, encryptor, CryptoStreamMode.Write))
                    using (var plainStream = new MemoryStream(data))
                    {
                        await plainStream.CopyToAsync(aesStream);
                    }

                    result = resultStream.ToArray();
                }
            }

            return result;
        }
    }
}
