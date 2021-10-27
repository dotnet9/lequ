using AutoMapper;
using Lequ.Blog.IService;
using Lequ.Blog.Model.ViewModels;
using Lequ.Blog.Service.ValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var posts = await _service.ToListWithCategoryByUserAsync(1);
            var postDtos = _mapper.Map<IEnumerable<BlogDto>>(posts);
            return View(postDtos);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            await GetAllCategories();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(BlogDto blog)
        {
            BlogValidator bv = new BlogValidator();
            var results = bv.Validate(blog);
            if (results.IsValid)
            {
                var blogModelFromDto = _mapper.Map<Model.Models.Blog>(blog);
                blogModelFromDto.Status = true;
                blogModelFromDto.CreateDate = DateTime.Now;
                blogModelFromDto.CreateBy = 1;
                await _service.AddAsync(blogModelFromDto);
                return RedirectToAction(nameof(ListByUser));
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

        public async Task<IActionResult> Remove(int id)
        {
            var blog = await _service.GetAsync(id);
            if (blog != null)
            {
                await _service.RemoveAsync(blog);
            }
            return RedirectToAction(nameof(ListByUser));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var blog = await _service.GetWithCategory(id);
            if (blog == null)
            {
                return RedirectToAction(nameof(ListByUser));
            }
            var blogDto = _mapper.Map<BlogDto>(blog);
            await GetAllCategories();
            return View(blogDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogDto blogDto)
        {
            var blogModelForDB = await _service.GetWithCategory(blogDto.ID);
            if (blogModelForDB == null)
            {
                return RedirectToAction(nameof(Edit), blogDto.ID);
            }
            _mapper.Map(blogDto, blogModelForDB, typeof(BlogDto), typeof(Model.Models.Blog));
            blogModelForDB.CreateBy = 1;
            blogModelForDB.UpdateBy = 1;
            blogModelForDB.UpdateDate = DateTime.Now;
            blogModelForDB.Status = true;
            await _service.UpdateAsync(blogModelForDB);
            return RedirectToAction(nameof(ListByUser));
        }


        private async Task<bool> GetAllCategories()
        {
            var categoryValues = (from x in await _service.GetAllAsync()
                                  select new SelectListItem
                                  {
                                      Text = x.Title,
                                      Value = x.ID.ToString()
                                  }).ToList();
            ViewBag.categories = categoryValues;
            return await Task.FromResult(true);
        }
    }
}
