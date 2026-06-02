using Microsoft.EntityFrameworkCore;
using TASK_9.Models;
using TASK_9.DAL;

namespace TASK_9.Repositories
{
    public class UserNoteRepository : IUserNoteRepository
    {
        private readonly AppDbContext _context;
        public UserNoteRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserNote>> GetUserNotesAsync(int userId)
        {
            return await _context.UserNotes
                .Where(note => note.AppUserId == userId)
                .OrderByDescending(note => note.CreatedAt)
                .ToListAsync();
        }

        public async Task AddUserNoteAsync(UserNote note)
        {
            await _context.UserNotes.AddAsync(note);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
