﻿using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class TagController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<PartialViewResult> BlogDetailsTagList()
		{
			return await Task.FromResult(PartialView());
		}
	}
}