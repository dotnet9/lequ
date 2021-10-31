using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

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
        public IViewComponentResult Invoke()
        {
            var values = _service.ListWithCategoryAsync().Result;
            return View(values);
        }
    }
}
