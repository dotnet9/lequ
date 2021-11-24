using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Category;

public class CategoryList : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly ICategoryService _service;

	public CategoryList(ICategoryService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var value = await _service.SelectAsync(x=>x.BlogCategories);
		return View((from p in value orderby p.BlogCategories?.Count descending select p).ToList());
	}
}