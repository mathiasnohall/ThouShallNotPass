using System;
using System.Threading.Tasks;
using ThouShallNotPass.Services.Models;

namespace ThouShallNotPass.Services
{
    public interface IUserService
    {
        Task<User> GetUser(Guid guid);
    }

    public class UserService : IUserService
    {
        public async Task<User> GetUser(Guid guid)
        {
            return await Task.FromResult<User>(new User());
        }
    }
}
