using TASK_9.DTOs;
using TASK_9.Models;
using TASK_9.Repositories;
using TASK_9.ViewModels;

namespace TASK_9.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;

        public UserService(IUserRepository userRepository, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(model.Email);

            if (existingUser != null) return false;

            var user = new AppUser
            {
                Email = model.Email,
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            user.PasswordHash = _passwordService.HashPassword(user, model.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }

        public async Task<AppUser?> AuthenticateUserAsync(LoginViewModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            if (user == null) return null;

            var isPasswordValid = _passwordService.VerifyPassword(user, user.PasswordHash, model.Password);

            if (!isPasswordValid) return null;
            return user;
        }

        public async Task<IEnumerable<AppUserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(user => new AppUserDto
            {
                Email = user.Email,
                NoteCount = user.UserNotes != null ? user.UserNotes.Count : 0,
                CreatedAt = user.CreatedAt
            }).ToList();
        }
    }
}
