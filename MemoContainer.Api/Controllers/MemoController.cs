using Microsoft.AspNetCore.Mvc;

namespace MemoContainer.Api.Controllers
{
    public class MemoController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return
            View();
        }
    }
}