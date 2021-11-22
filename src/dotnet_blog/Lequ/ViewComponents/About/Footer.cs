using AutoMapper;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.About;

public class Footer : ViewComponent
{
	private readonly ILinkService _linkService;
	private readonly IMapper _mapper;
	private readonly IAboutService _service;

	public Footer(IAboutService service, ILinkService linkService, IMapper mapper)
	{
		_service = service;
		_linkService = linkService;
		_mapper = mapper;
	}

	public async Task<IViewComponentResult> InvokeAsync()
	{
		var vm = new FooterDto();
		vm.FriendLinks = await _linkService.SelectAsync(x => x.Status == (int)ModelStatus.Normal, x => x.Index,
			SortDirection.Ascending);
		return View(vm);
	}
}