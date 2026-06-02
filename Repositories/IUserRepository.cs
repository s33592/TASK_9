using TASK_9.Models;

namespace TASK_9.Repositories
{
    public interface IUserRepository
    {
        Task<AppUser?> GetUserByEmailAsync(string email);

        Task<IEnumerable<AppUser>> GetAllUsersAsync();
        Task AddUserAsync(AppUser user);
        Task SaveChangesAsync();
    }
}
