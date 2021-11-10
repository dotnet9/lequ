using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lequ.Controllers
{
	public class ErrorPageController : Controller
	{
		public async Task<IActionResult> Error()
		{
			return await Task.FromResult(View());
		}
	}
}
