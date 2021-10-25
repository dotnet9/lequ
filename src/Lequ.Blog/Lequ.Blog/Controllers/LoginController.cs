using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
