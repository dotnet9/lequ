using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Lequ.Blog.Service.ValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Blog.Controllers
{
    [AllowAnonymous]
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
            var posts = await _service.ToListWithCategoryAsync();
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }

        public async Task<IActionResult> ReadAll(int id)
        {
            ViewBag.id = id;
            var posts = await _service.ListAsync(x => x.ID == id);
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }

        public async Task<IActionResult> ListByUser()
        {
            var posts = await _service.ToListByUserIDAsync(1);
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return await Task.FromResult(View());
        }

        [HttpPost]
        public async Task<IActionResult> Add(BlogDto blog)
        {
            BlogValidator bv = new BlogValidator();
            var results = bv.Validate(blog);
            if (results.IsValid)
            {
                blog.Status = true;
                blog.CreateDate = DateTime.Now;
                blog.CreateBy = 1;
                var blogModelFromDto = _mapper.Map<Model.Models.Blog>(blog);
                await _service.AddAsync(blogModelFromDto);
                return RedirectToAction(nameof(ListByUser), "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
    }
}
