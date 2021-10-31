using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class ContactController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}
	}
}
