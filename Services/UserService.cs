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

            user.PasswordHash = _passwordService.HashPassword(user,model.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return true;
        }
    }
}
