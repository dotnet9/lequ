using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class TagController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}