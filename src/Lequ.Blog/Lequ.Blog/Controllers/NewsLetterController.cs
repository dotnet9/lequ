using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterService _service;
        private readonly IMapper _mapper;

        public NewsLetterController(INewsLetterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.Status = true;
            await _service.AddAsync(newsLetter);
            return PartialView();
        }
    }
}
