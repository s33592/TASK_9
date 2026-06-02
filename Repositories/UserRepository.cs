using Microsoft.EntityFrameworkCore;
using TASK_9.DAL;
using TASK_9.Models;
namespace TASK_9.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<AppUser?> GetUserByEmailAsync(string email)
        {
            return await _context.AppUsers
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<AppUser>> GetAllUsersAsync()
        {
            return await _context.AppUsers
                .Include(user => user.UserNotes)
                .ToListAsync();
        }
        public async Task AddUserAsync(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
