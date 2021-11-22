using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Blog;

public class ReadAll : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly IBlogService _service;
	private readonly IUserService _userService;

	public ReadAll(IBlogService service, IUserService userService, IMapper mapper)
	{
		_service = service;
		_userService = userService;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync(int id)
	{
		var blog = await _service.GetDetailsAsync(id);
		if (blog != null) blog.CreateUser = await _userService.GetAsync(x => x.ID == blog.CreateUserID);
		return View(blog);
	}
}