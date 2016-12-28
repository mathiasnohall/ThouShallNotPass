using System.Linq;
using Xunit;

namespace ThouShallNotPass.Services.Test
{
    public class PasswordGeneratorServiceTests
    {
        private readonly IPasswordGeneratorService _sut;

        public PasswordGeneratorServiceTests()
        {
            _sut = new PasswordGeneratorService();
        }

        [Fact]
        public void PasswordGeneratorService_Generate()
        {
            var generatedPassword = _sut.Generate();

            Assert.Equal(12, generatedPassword.Count());
        }
    }
}
