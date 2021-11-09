using AutoMapper;
using Lequ.IService;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class SubscribeEmailController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubscribeEmailService _service;

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
            subscribeEmail.CreateDate = DateTime.Now;
            subscribeEmail.UpdateDate = DateTime.Now;
            await _service.InsertAsync(subscribeEmail);
            return PartialView();
        }
    }
}