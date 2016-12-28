using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThouShallNotPass.Services
{
    public interface IPasswordGeneratorService
    {
        string Generate();
    }

    public class PasswordGeneratorService : IPasswordGeneratorService
    {
        public PasswordGeneratorService()
        {
        }

        public string Generate()
        {
            throw new NotImplementedException();
        }
    }
}
