using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.User;

public class UserPopularBlogList : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly IBlogService _service;

	public UserPopularBlogList(IBlogService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		var value = await _service.SelectAsync(6, 1, x => x.CreateUserID == id, x => x.CreateDate,
			SortDirection.Descending);
		return View(value.Item1);
	}
}