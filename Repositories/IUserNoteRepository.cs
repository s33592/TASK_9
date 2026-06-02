using TASK_9.Models;

namespace TASK_9.Repositories
{
    public interface IUserNoteRepository
    {
        Task<IEnumerable<UserNote>> GetUserNotesAsync(int userId);

        Task AddUserNoteAsync(UserNote note);

        Task SaveChangesAsync();
    }
}
