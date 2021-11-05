using AutoMapper;
using Lequ.IService;
using Lequ.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _service;
        private readonly IAlbumService _AlbumService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private const int PAGE_SIZE = 6;
        public BlogController(IBlogService service, IAlbumService albumService, ICategoryService categoryService, ITagService tagService, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
            _AlbumService = albumService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.Page = page;
            return await Task.FromResult(View());
        }

        public async Task<IActionResult> ListDetails()
        {
            return await Task.FromResult(PartialView());
        }

        public async Task<IActionResult> ListDetailsLoadMore(int? categoryID, int? tagID, int? albumID, int page = 1)
        {
            List<Blog>? blogs;
            if (categoryID.HasValue)
            {
                var values = await _service.ListDetailsAsync(x => x.BlogCategories != null && x.BlogCategories.Any(p => p.CategoryID == categoryID.Value), page, PAGE_SIZE);
                blogs = values.Item1;
            }
            else if (tagID.HasValue)
            {
                var values = await _service.ListDetailsAsync(x => x.BlogTags != null && x.BlogTags.Any(cu => cu.TagID == tagID.Value), page, PAGE_SIZE);
                blogs = values.Item1;
            }
            else if (albumID.HasValue)
            {
                var values = await _service.ListDetailsAsync(x => x.BlogAlbums != null && x.BlogAlbums.Any(cu => cu.AlbumID == albumID.Value), page, PAGE_SIZE);
                blogs = values.Item1;
            }
            else
            {
                var values = await _service.ListDetailsAsync(x => x.Status == ModelStatus.Normal, page, PAGE_SIZE);
                blogs = values.Item1;
            }
            if (blogs.Count > 0)
            {
                return PartialView(blogs);
            }
            return Json("");
        }

        [HttpGet]
        public async Task<IActionResult> ListByUser()
        {
            return await Task.FromResult(PartialView());
        }

        [HttpGet]
        public async Task<IActionResult> ListByAlbum(int albumID)
        {
            var category = await _AlbumService.GetAsync(x => x.ID == albumID);
            return await Task.FromResult(View(category));
        }

        [HttpGet]
        public async Task<IActionResult> ListByCategory(int categoryID)
        {
            var category = await _categoryService.GetAsync(x => x.ID == categoryID);
            return await Task.FromResult(View(category));
        }

        [HttpGet]
        public async Task<IActionResult> ListByTag(int tagID)
        {
            var category = await _tagService.GetAsync(x => x.ID == tagID);
            return await Task.FromResult(View(category));
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
        public async Task<IActionResult> Details(int id)
        {
            var blog = await _service.GetDetailsAsync(id);
            ViewBag.userID = blog?.UserID;
            ViewBag.id = id;
            return await Task.FromResult(PartialView());
        }
    }
}
