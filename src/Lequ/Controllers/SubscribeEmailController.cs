using AutoMapper;
using Lequ.IService;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class SubscribeEmailController : Controller
    {
        private readonly ISubscribeEmailService _service;
        private readonly IMapper _mapper;

        public SubscribeEmailController(ISubscribeEmailService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> AddEmail()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpPost]
        public async Task<IActionResult> AddEmail(SubscribeEmail subscribeEmail)
        {
            await _service.InsertAsync(subscribeEmail);
            return PartialView();
        }
    }
}
