using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
