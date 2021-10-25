using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public BlogController(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _service.GetListWithCategory();
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }

        public async Task<IActionResult> ReadAll(int id)
		{
            ViewBag.id = id;
            var posts = await _service.List(x=>x.ID==id);
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
		}
    }
}
