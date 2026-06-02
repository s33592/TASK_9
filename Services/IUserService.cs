using TASK_9.Models;
using TASK_9.DTOs;
using TASK_9.ViewModels;

namespace TASK_9.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<AppUser?> AuthenticateUserAsync(LoginViewModel model);

        Task<IEnumerable<AppUserDto>> GetAllUsersAsync();
    }
}
