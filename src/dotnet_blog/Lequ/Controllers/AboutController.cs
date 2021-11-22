using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class AboutController : Controller
{
	private readonly IMapper _mapper;
	private readonly IAboutService _service;

	public AboutController(IAboutService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	[AllowAnonymous]
	public async Task<IActionResult> Index()
	{
		var about = await _service.GetAsync(x => x.ID > 0);
		return View(about);
	}

	[HttpGet]
	public async Task<IActionResult> Update()
	{
		var about = await _service.GetAsync(x => x.ID > 0);
		return await Task.FromResult(View(about));
	}

	[HttpPost]
	public async Task<IActionResult> Update(About about)
	{
		var dbAbout = await _service.GetAsync(x => x.ID > 0);
		if (dbAbout == null)
		{
			about.CreateDate = DateTime.Now;
			await _service.InsertAsync(about);
		}
		else
		{
			dbAbout.Details1 = about.Details1;
			dbAbout.UpdateDate = DateTime.Now;
			await _service.UpdateAsync(dbAbout);
		}

		return RedirectToAction(nameof(Index));
	}
}