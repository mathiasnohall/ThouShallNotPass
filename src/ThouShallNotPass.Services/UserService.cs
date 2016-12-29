using System;
using System.Net.Http;
using System.Threading.Tasks;
using ThouShallNotPass.Services.Models;

namespace ThouShallNotPass.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid guid);

        Task<User> CreateUser(string userName);
    }

    public class UserService : IUserService
    {
        private readonly ICryptoService _cryptoService;
        private readonly IHttpClient _httpClient;

        public UserService(ICryptoService cryptoService)
        {

        }

        public async Task<User> CreateUser(string userName)
        {
            _httpClient.GetAsync

            return await Task.FromResult<User>(new User());
        }

        public async Task<User> GetUser(Guid guid)
        {
            return await Task.FromResult<User>(new User());
        }
    }
}
