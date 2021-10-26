using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.ViewComponents.Blog
{
    public class UserLatestBlog : ViewComponent
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public UserLatestBlog(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(int id)
        {
            var posts = _service.ToListByUserIDAsync(1).Result;
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }
    }
}
