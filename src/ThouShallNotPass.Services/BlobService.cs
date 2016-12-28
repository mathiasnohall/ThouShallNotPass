using System.Threading.Tasks;
using ThouShallNotPass.Services.Models;

namespace ThouShallNotPass.Services
{
    public interface IBlobService
    {
        Task<UserBlob> GetUserBlob(User user);
    }

    public class BlobService : IBlobService
    {
        public async Task<UserBlob> GetUserBlob(User user)
        {
            return await Task.FromResult<UserBlob>(new UserBlob());
        }
    }
}
