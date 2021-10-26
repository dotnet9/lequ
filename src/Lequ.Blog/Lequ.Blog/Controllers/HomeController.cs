using Lequ.Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lequ.Blog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}

		public async Task<IActionResult> Privacy()
		{
			return await Task.FromResult(View());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public async Task<IActionResult> Error()
		{
			return await Task.FromResult(View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
		}

		public async Task<IActionResult> Test()
		{
			return await Task.FromResult(View());
		}
	}
}