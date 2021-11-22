using System.Text.Json;
using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers;

public class ChartController : Controller
{
	private readonly IBlogService _blogService;
	private readonly ICategoryService _categoryService;
	private readonly IMapper _mapper;

	public ChartController(ICategoryService categoryService, IBlogService blogService, IMapper mapper)
	{
		_categoryService = categoryService;
		_blogService = blogService;
		_mapper = mapper;
	}

	public async Task<IActionResult> CategoryCount()
	{
		return await Task.FromResult(View());
	}

	[HttpPost]
	public async Task<IActionResult> CategoryCountData()
	{
		var json = Json(await CategoryList(), new JsonSerializerOptions());
		return await Task.FromResult(json);
	}


	public async Task<List<CountViewModel>> CategoryList()
	{
		var categories = from p in await _categoryService.SelectAsync(x => x.BlogCategories)
			select new CountViewModel
			{
				Name = p.Name,
				Count = p.BlogCategories?.Count()
			};
		return await Task.FromResult(categories.ToList());
	}

	public async Task<IActionResult> BlogCount()
	{
		return await Task.FromResult(View());
	}

	[HttpPost]
	public async Task<IActionResult> BlogCountData()
	{
		var json = Json(await BlogList(), new JsonSerializerOptions());
		return await Task.FromResult(json);
	}

	public async Task<List<CountViewModel>> BlogList()
	{
		var blogs = from p in await _blogService.SelectAsync(x => x.ID > 0)
			select new CountViewModel
			{
				Name = p.Title,
				Count = p.Rating
			};
		return await Task.FromResult(blogs.ToList());
	}

	public async Task<IActionResult> BlogCountColumn()
	{
		return await Task.FromResult(View());
	}

	public async Task<IActionResult> BlogCountLine()
	{
		return await Task.FromResult(View());
	}
}