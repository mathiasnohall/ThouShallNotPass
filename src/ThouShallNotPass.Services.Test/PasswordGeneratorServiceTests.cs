using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ThouShallNotPass.Services.Test
{
    public class PasswordGeneratorServiceTests
    {
        private readonly IPasswordGeneratorService _sut;
        private int _length;

        public PasswordGeneratorServiceTests()
        {
            _sut = new PasswordGeneratorService();
            _length = 12;
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldEqualToLength()
        {
            var generatedPassword = _sut.Generate(_length);

            Assert.Equal(_length, generatedPassword.Count());
        }

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldGenerateRandomChars()
        {
            var generatedPassword = _sut.Generate(_length);

            var validChars = new List<char>();
            for (int x = 33; x <= 122; x++) // valid ascii numbers 33-122
            {
                validChars.Add((char)x);
            }

            var result = false;

            foreach(var character in generatedPassword.ToArray())
            {
                result = validChars.Contains(character) ? true : false;                
            }

            Assert.True(result);
        }
        

        [Fact]
        public void PasswordGeneratorService_Generate_ShouldProblablyNotGenerateSamePasswordAgain()
        {
            var generatedPassword = _sut.Generate(_length);

            var generatedPassword2 = _sut.Generate(_length);

            Assert.NotEqual(generatedPassword, generatedPassword2);
        }
    }
}
