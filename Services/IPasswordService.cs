using TASK_9.Models;

namespace TASK_9.Services
{
    public interface IPasswordService
    {
        string HashPassword(AppUser user,string password);
        bool VerifyPassword(AppUser user, string hashedPassword, string providedPassword);
    }
}
