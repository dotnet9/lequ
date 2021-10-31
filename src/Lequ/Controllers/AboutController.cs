﻿using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class AboutController : Controller
	{
		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<PartialViewResult> Footer()
		{
			return await Task.FromResult(PartialView());
		}

		[HttpGet]
		public async Task<PartialViewResult> MeetTheTeam()
		{
			return await Task.FromResult(PartialView());
		}
	}
}