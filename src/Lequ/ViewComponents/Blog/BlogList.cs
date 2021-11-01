using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace Lequ.ViewComponents.Blog
{
    public class BlogList : ViewComponent
    {
        private readonly IBlogService _service;
        private readonly IMapper _mapper;

        public BlogList(IBlogService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IViewComponentResult Invoke(int page = 1, int pageSize = 6)
        {
            var values = _service.SelectAsync().Result;

            return View(values.ToPagedList(page, pageSize));
        }
    }
}
