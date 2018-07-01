using System;
using System.Threading.Tasks;
using MemoContainer.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace MemoContainer.Api.Controllers
{
    public class MemoController : Controller
    {
        public MemoController(IUserService userService)
        {
        }

        [HttpGet]
        public async Task<ActionResult> GetTicket(Guid ticketId)
        {
            
        }
    }
}