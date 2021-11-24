using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Album;

public class FeaturedAblumList : ViewComponent
{
	private readonly IMapper _mapper;
	private readonly IAlbumService _service;

	public FeaturedAblumList(IAlbumService service, IMapper mapper)
	{
		_service = service;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var value = await _service.SelectAsync();
		return View(value);
	}
}