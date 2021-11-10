using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Lequ.Controllers
{
	public class ErrorController : Controller
	{
		public async Task<IActionResult> Error()
		{
			return await Task.FromResult(View());
		}
	}
}
