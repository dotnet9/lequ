using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class ErrorPageController : Controller
{
	public async Task<IActionResult> Error()
	{
		return await Task.FromResult(View());
	}
}