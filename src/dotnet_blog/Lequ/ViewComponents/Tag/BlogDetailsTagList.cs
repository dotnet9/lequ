using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Tag;

public class BlogDetailsTagList : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly IBlogService _service;

	public BlogDetailsTagList(IBlogService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync(int blogID)
	{
		var value = await _service.GetDetailsAsync(blogID);
		return View(value?.BlogTags);
	}
}