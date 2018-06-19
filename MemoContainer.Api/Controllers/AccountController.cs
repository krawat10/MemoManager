using Microsoft.AspNetCore.Mvc;

namespace MemoContainer.Api.Controllers
{
    public class AccountController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}