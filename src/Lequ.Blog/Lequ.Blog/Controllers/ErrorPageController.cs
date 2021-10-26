using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1()
        {
            return View();
        }
    }
}
