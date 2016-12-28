using System;

namespace ThouShallNotPass.Services
{
    public interface IPasswordGeneratorService
    {
        string Generate(int length);
    }

    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        private readonly Random _random;

        public PasswordGeneratorService()
        {
            _random = new Random();
        }


        // ASCII chars used 33-122
        public string Generate(int lenght)
        {
            var generatedPassword = new char[lenght];            

            for(int x = 0; x < generatedPassword.Length; x++)
            {
                generatedPassword[x] = (char)_random.Next(33, 122);
            }

            return new String(generatedPassword);
        }
    }
}
