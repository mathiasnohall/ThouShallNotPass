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
        public void PasswordGeneratorService_Generate_ShouldBe12CharsLong()
        {
            var generatedPassword = _sut.Generate();

            Assert.Equal(12, generatedPassword.Count());
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldContainAtleastOneNumber()
        {
            var generatedPassword = _sut.Generate();

            bool result = false;

            foreach(var character in generatedPassword.ToArray())
            {
                for(int x = 48; x <= 57; x++) // valid ascii numbers 48 - 57
                {
                    if (character == (char)x)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                    break;
            }

            Assert.True(result);
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldContainAtleastOneSpecialChar()
        {
            var generatedPassword = _sut.Generate();

            bool result = false;

            foreach (var character in generatedPassword.ToArray())
            {
                for (int x = 33; x <= 47; x++) // valid ascii special case chars 33 - 47
                {
                    if (character == (char)x)
                    {
                        result = true;
                        break;
                    }
                }
                for (int x = 58; x <= 64; x++) // valid ascii special case chars 58 - 64
                {
                    if (character == (char)x)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                    break;
            }

            Assert.True(result);
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldContainAtleastOneUpercaseChar()
        {
            var generatedPassword = _sut.Generate();

            bool result = false;

            foreach (var character in generatedPassword.ToArray())
            {
                for (int x = 65; x <= 90; x++) // valid ascii uppercase chars 65 - 90
                {
                    if (character == (char)x)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                    break;
            }

            Assert.True(result);
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldContainAtleastOneLowecaseChar()
        {
            var generatedPassword = _sut.Generate();

            bool result = false;

            foreach (var character in generatedPassword.ToArray())
            {
                for (int x = 65; x <= 90; x++) // valid ascii lowercase chars 97 - 122
                {
                    if (character == (char)x)
                    {
                        result = true;
                        break;
                    }
                }
                if (result == true)
                    break;
            }

            Assert.True(result);
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldProblablyNotGenerateSamePasswordAgain()
        {
            var generatedPassword = _sut.Generate();

            var generatedPassword2 = _sut.Generate();

            Assert.NotEqual(generatedPassword, generatedPassword2);
        }
    }
}
