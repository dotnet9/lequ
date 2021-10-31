using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class BlogController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
