using Microsoft.AspNetCore.Identity;
using TASK_9.Models;

namespace TASK_9.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<AppUser> _hasher;
        
        public PasswordService()
        {
            _hasher = new PasswordHasher<AppUser>();
        }

        public string HashPassword(AppUser user, string password)
        {
            return _hasher.HashPassword(user, password);
        }
        
        public bool VerifyPassword(AppUser user, string hashedPassword, string providedPassword)
        {
            var result = _hasher.VerifyHashedPassword(user, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
