using AutoMapper;
using Lequ.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
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

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.Page = page;
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> ListWithCategory()
        {
            return await Task.FromResult(PartialView());
        }

        public async Task<IActionResult> ListWithCategoryLoadMore(int page = 1)
        {
            var values = await _service.ListWithCategoryAsync(page, 6);
            if (values.Item1.Count > 0)
            {
                return PartialView(values.Item1);
            }
            return Json("");
        }

        [HttpGet]
        public async Task<IActionResult> ListByUser()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> ListByCategory()
        {
            return await Task.FromResult(View());
        }

        [HttpGet]
        public async Task<IActionResult> Featured()
        {
            ViewBag.title1 = "test title";
            ViewBag.img1 = "/Front/images/img_3.jpg";
            ViewBag.date1 = DateTime.Now;

            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> OtherFeatured()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> Cover()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            return await Task.FromResult(PartialView());
        }
    }
}
