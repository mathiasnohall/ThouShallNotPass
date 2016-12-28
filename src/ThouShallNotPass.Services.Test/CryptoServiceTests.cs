using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ThouShallNotPass.Services.Test
{
    public class CryptoServiceTests
    {
        private readonly ICryptoService _sut;
        private readonly string _key;

        private byte[] _nonEncryptedData;

        public CryptoServiceTests()
        {
            _sut = new CryptoService();
            _key = "SomeSecretKey";

            _nonEncryptedData = ASCIIEncoding.ASCII.GetBytes("THOUSHALLNOTPASS");
        }

        [Fact]
        public async Task CryptoService_Encrypt_ShouldEncrypt()
        {
            var result = await _sut.Encrypt(_key, _nonEncryptedData);

            Assert.NotEqual(_nonEncryptedData, result);
        }


        [Fact]
        public async Task CryptoService_Decrypt_ShouldDecryptEncryptedData()
        {
            var encryptedData = await _sut.Encrypt(_key, _nonEncryptedData);

            var result = await _sut.Decrypt(_key, encryptedData);

            Assert.Equal(_nonEncryptedData, result);
        }
    }
}
