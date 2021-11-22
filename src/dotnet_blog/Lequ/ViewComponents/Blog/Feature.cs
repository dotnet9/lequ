using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Blog;

public class Feature : ViewComponent
{
	private const int PAGE_SIZE = 6;
	private readonly IMapper _mapper;
	private readonly IBlogService _service;

	public Feature(IBlogService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		var values = await _service.ListDetailsAsync(x => x.Status == (int)ModelStatus.Normal, 1, PAGE_SIZE);
		return View(values.Item1);
	}
}