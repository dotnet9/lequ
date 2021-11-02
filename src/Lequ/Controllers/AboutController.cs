using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
	public class AboutController : Controller
	{
		private readonly IAboutService _service;
		private readonly IMapper _mapper;

		public AboutController(IAboutService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index()
		{
			return await Task.FromResult(View());
		}

		[HttpGet]
		public async Task<IActionResult> MeetTheTeam()
		{
			return await Task.FromResult(PartialView());
		}
	}
}
