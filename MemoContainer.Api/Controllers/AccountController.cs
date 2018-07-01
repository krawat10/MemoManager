using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.Commands;
using MemoContainer.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MemoContainer.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Get()
        {
            if (User == null)
            {
                return new UnauthorizedResult();
            }
            var userId = User.Identity.IsAuthenticated ? Guid.Parse(User.Identity.Name) : Guid.Empty;

            return Json(await _userService.GetUserAsync(userId));
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login command)
        {
            return Json(await _userService.LoginByEmailAsync(command.Email, command.Password));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(Register command)
        {
            await _userService.RegisterAsync(
                Guid.NewGuid(),
                command.Nickname,
                command.Email,
                command.FirstName,
                command.LastName,
                command.Password);

            return Created("/register", null);
        }
    }
}