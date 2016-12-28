using System.Security.Cryptography;
using System.Text;

namespace ThouShallNotPass.Services.Extensions
{
    public static class StringExtensions
    {
        public static byte[] Tosha256(this string password)
        {
            using (var sha = SHA256.Create())
            {
                System.Text.StringBuilder hash = new System.Text.StringBuilder();
                byte[] hashedPassword = sha.ComputeHash(Encoding.UTF8.GetBytes(password), 0, Encoding.UTF8.GetByteCount(password));

                return hashedPassword;
            }
        }
    }
}
