using System.Diagnostics.CodeAnalysis;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class TagController : Controller
{
	private readonly ITagService _service;

	public TagController(ITagService service)
	{
		_service = service;
	}

	public IActionResult Index()
	{
		return View();
	}

	[Authorize]
	public async Task<IActionResult> List(int page = 1)
	{
		var vm = new PagingDtoBase<Tag>();
		var pageTag = await _service.SelectAsync(pageSize: GlobalVars.PaginationMaxPageSize, pageIndex: page,
			whereLambda: x => x.ID > 0, orderByLambda: x => x.Name,
			sortDirection: SortDirection.Ascending);

		vm.PageCount = (int)Math.Ceiling((decimal)pageTag.Item2 / GlobalVars.PaginationMaxPageSize);
		vm.PageIndex = page < 1 ? 1 : page;
		vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
		vm.Datas = pageTag.Item1;

		return Json(vm);
	}

	public async Task<IActionResult> Get(int id)
	{
		return Json(await _service.GetAsync(x => x.ID == id));
	}

	public async Task<IActionResult> Delete(int id)
	{
		var deleteResult = await _service.DeleteAsync(x => x.ID == id);
		if (deleteResult > 0)
		{
			return Json(MessageDto<string>.Success());
		}

		return Json(MessageDto<string>.Fail("Deletion failed!"));
	}

	public async Task<IActionResult> DeleteMuti(string ids)
	{
		var idArray = ids.Split(',').ToList().ConvertAll(x => int.Parse(x));
		var deleteResult = await _service.DeleteAsync(x => idArray.Contains(x.ID));
		if (deleteResult > 0)
		{
			return Json(MessageDto<string>.Success());
		}

		return Json(MessageDto<string>.Fail("Deletion failed!"));
	}

	[HttpPost]
	public async Task<IActionResult> Save(Tag? tag)
	{
		if (tag == null) return RedirectToAction(nameof(List));
		if (tag.ID > 0)
		{
			if (await _service.IsExistAsync(x => x.Name == tag.Name && x.ID != tag.ID))
			{
				return Json(MessageDto<string>.Fail("The name cannot be duplicate"));
			}

			var dbTag = await _service.GetAsync(x => x.ID == tag.ID);
			if (dbTag == null) return RedirectToAction(nameof(List));
			dbTag.Name = tag.Name;
			dbTag.Description = tag.Description;
			dbTag.UpdateDate = DateTime.Now;
			await _service.UpdateAsync(dbTag);
		}
		else
		{
			if (await _service.IsExistAsync(x => x.Name == tag.Name))
			{
				return Json(MessageDto<string>.Fail("The name cannot be duplicate"));
			}

			tag.CreateDate = DateTime.Now;
			tag.StatusEnum = ModelStatus.Normal;
			await _service.InsertAsync(tag);
		}

		return Json(MessageDto<string>.Success());
	}
}