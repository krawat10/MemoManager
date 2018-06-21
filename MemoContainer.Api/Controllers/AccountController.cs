using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.Commands;
using MemoContainer.Infrastructure.Services;
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

        [HttpPost("login")]
        public async Task<ActionResult> Login(Login command)
        {
            return Json(await _userService.LoginAsync(command.Email, command.Password));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(Register command)
        {
            await _userService.RegisterAsync(
                Guid.NewGuid(),
                command.Email,
                command.FirstName,
                command.LastName,
                command.Password);

            return Created("/register", null);
        }
    }
}