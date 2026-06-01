using TASK_9.ViewModels;

namespace TASK_9.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
    }
}
