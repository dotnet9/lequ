using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Lequ.Controllers;

public class LinkController : Controller
{
	private readonly IStringLocalizer<LinkController> _localizer;
	private readonly IMapper _mapper;
	private readonly ILinkService _service;

	public LinkController(ILinkService service, IMapper mapper, IStringLocalizer<LinkController> localizer)
	{
		_service = service;
		_mapper = mapper;
		_localizer = localizer;
	}

	[Authorize]
	public async Task<IActionResult> AdminLinkList()
	{
		var allLinks = await _service.SelectAsync(x => x.ID > 0, x => x.Index, SortDirection.Ascending);

		return View(allLinks);
	}

	[HttpGet]
	public async Task<IActionResult> Create()
	{
		var addLinkDto = new LinkForCreationDto();
		addLinkDto.StatusEnum = ModelStatus.Normal;
		addLinkDto.Statuses = Enum.GetValues<ModelStatus>();
		return await Task.FromResult(View(addLinkDto));
	}

	[HttpPost]
	public async Task<IActionResult> Create(LinkForCreationDto addLinkDto)
	{
		if (ModelState.IsValid)
		{
			var linkFromDatabase = _mapper.Map<Link>(addLinkDto);
			linkFromDatabase.CreateDate = DateTime.Now;
			linkFromDatabase.CreateUserID = HttpContext.Session.Get<int>(GlobalVars.SessionUserIdKey);
			await _service.InsertAsync(linkFromDatabase);
			return RedirectToAction(nameof(AdminLinkList));
		}

		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Delete(int id)
	{
		await _service.DeleteAsync(x => x.ID == id);
		return RedirectToAction(nameof(AdminLinkList));
	}


	[HttpGet]
	public async Task<IActionResult> Update(int? id)
	{
		if (id == null) return NotFound();
		var linkFromDatabase = await _service.GetAsync(x => x.ID == id);
		if (linkFromDatabase == null) return NotFound();
		var editLinkDto = _mapper.Map<LinkForUpdateDto>(linkFromDatabase);
		editLinkDto.Statuses = Enum.GetValues<ModelStatus>();
		return View(editLinkDto);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Update(int id, LinkForUpdateDto editLinkDto)
	{
		if (id != editLinkDto.ID) return NotFound();
		if (ModelState.IsValid)
		{
			var linkFromDatabase = await _service.GetAsync(x => x.ID == editLinkDto.ID);
			if (linkFromDatabase == null) return View();
			linkFromDatabase.Name = editLinkDto.Name;
			linkFromDatabase.Url = editLinkDto.Url;
			linkFromDatabase.Description = editLinkDto.Description;
			linkFromDatabase.Index = editLinkDto.Index;
			linkFromDatabase.StatusEnum = editLinkDto.StatusEnum;
			linkFromDatabase.UpdateDate = DateTime.Now;
			linkFromDatabase.UpdateUserID = HttpContext.Session.Get<int>(GlobalVars.SessionUserIdKey);

			await _service.UpdateAsync(linkFromDatabase);
			return RedirectToAction(nameof(AdminLinkList));
		}

		return View();
	}
}