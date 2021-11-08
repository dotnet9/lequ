using AutoMapper;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
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
