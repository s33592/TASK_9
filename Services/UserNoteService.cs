using TASK_9.DTOs;
using TASK_9.Models;
using TASK_9.Repositories;

namespace TASK_9.Services
{
    public class UserNoteService : IUserNoteService
    {
        private readonly IUserNoteRepository _noteRepository;
        public UserNoteService(IUserNoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public async Task<IEnumerable<UserNoteDto>> GetUserNotesAsync(int userId)
        {
           var notes = await _noteRepository.GetUserNotesAsync(userId);

            return notes.Select(note => new UserNoteDto
            {
                Title = note.Title,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            }).ToList();
        }

        public async Task AddUserNoteAsync(int userId, ViewModels.AddNoteViewModel model)
        {
            var note = new UserNote
            {
                AppUserId = userId,
                Title = model.Title,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow
            };

            await _noteRepository.AddUserNoteAsync(note);
            await _noteRepository.SaveChangesAsync();
        }
    }
}
