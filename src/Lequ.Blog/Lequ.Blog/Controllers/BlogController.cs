using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            this._blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var posts = await _blogService.GetListWithCategory();
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }
    }
}
