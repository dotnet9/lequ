using AutoMapper;
using Lequ.IService;
using Lequ.Model;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class AboutController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAboutService _service;

        public AboutController(IAboutService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var value = await _service.GetAsync(x => x.Status == (int)ModelStatus.Normal);
            return View(value);
        }

        [HttpGet]
        public async Task<IActionResult> MeetTheTeam()
        {
            return await Task.FromResult(PartialView());
        }
    }
}