using System;

namespace ThouShallNotPass.Services.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string EncryptedPassword { get; set; }
    }
}
