using TASK_9.DTOs;
using TASK_9.ViewModels;

namespace TASK_9.Services
{
    public interface IUserNoteService
    {
        Task<IEnumerable<UserNoteDto>> GetUserNotesAsync(int userId);
        Task AddUserNoteAsync(int userId, AddNoteViewModel model);
    }
}
