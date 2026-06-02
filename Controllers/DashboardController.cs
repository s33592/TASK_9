using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TASK_9.Services;
using TASK_9.ViewModels;
using System.Security.Claims;

namespace TASK_9.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IUserNoteService _noteService;
        private readonly IUserService _userService;

        public DashboardController(IUserNoteService noteService, IUserService userService)
        {
            _noteService = noteService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdString)) return RedirectToAction("Login", "Account");

            var notes = await _noteService.GetUserNotesAsync(int.Parse(userIdString));
            return View(notes);
        }

        [HttpGet]
        public IActionResult NewNote()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewNote(AddNoteViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userIdString)) return RedirectToAction("Login", "Account");

            await _noteService.AddUserNoteAsync(int.Parse(userIdString), model);
            return RedirectToAction("Index", "Dashboard");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Admin()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }
    }
}
