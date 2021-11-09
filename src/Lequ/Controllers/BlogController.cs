using AutoMapper;
using Lequ.Common;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Lequ.Model.ViewModels;
using Lequ.Model.ViewModels.Blogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lequ.Controllers
{
    public class BlogController : Controller
    {
        private const int PAGE_SIZE = 6;
        private readonly IAlbumService _AlbumService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IBlogService _service;
        private readonly ITagService _tagService;
        private readonly IUserService _userService;

        public BlogController(IBlogService service, IUserService userService, IAlbumService albumService,
            ICategoryService categoryService, ITagService tagService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
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
                var values = await _service.ListDetailsAsync(
                    x => x.BlogCategories != null && x.BlogCategories.Any(p => p.CategoryID == categoryID.Value), page,
                    PAGE_SIZE);
                blogs = values.Item1;
            }
            else if (tagID.HasValue)
            {
                var values = await _service.ListDetailsAsync(
                    x => x.BlogTags != null && x.BlogTags.Any(cu => cu.TagID == tagID.Value), page, PAGE_SIZE);
                blogs = values.Item1;
            }
            else if (albumID.HasValue)
            {
                var values = await _service.ListDetailsAsync(
                    x => x.BlogAlbums != null && x.BlogAlbums.Any(cu => cu.AlbumID == albumID.Value), page, PAGE_SIZE);
                blogs = values.Item1;
            }
            else
            {
                var values = await _service.ListDetailsAsync(x => x.Status == (int)ModelStatus.Normal, page, PAGE_SIZE);
                blogs = values.Item1;
            }

            if (blogs.Count > 0) return PartialView(blogs);
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
            if (blog == null) return RedirectToAction(nameof(Index));
            var vm = new DetailsViewModel
            {
                ID = id,
                UserID = blog.CreateUserID!.Value
            };
            return await Task.FromResult(PartialView(vm));
        }


        public async Task<IActionResult> AdminBlogList(int page = 1)
        {
            var vm = new PagingViewModelBase<Blog>();
            var pageBlog =
                await _service.ListDetailsAsync(x => x.ID > 0, pageIndex: page, pageSize: GlobalVar.SMALL_PAGE_SIZE);
            var users = await _userService.SelectAsync();
            if (pageBlog != null && users != null)
            {
                pageBlog.Item1.ForEach(cu =>
                {
                    if (cu.CreateUserID.HasValue)
                        cu.CreateUser = users.FirstOrDefault(x => x.ID == cu.CreateUserID.Value);
                    if (cu.UpdateUserID.HasValue)
                        cu.UpdateUser = users.FirstOrDefault(x => x.ID == cu.UpdateUserID.Value);
                });
                vm.PageCount = (pageBlog.Item2 + GlobalVar.SMALL_PAGE_SIZE - 1) / GlobalVar.SMALL_PAGE_SIZE;
                vm.PageIndex = page < 1 ? 1 : page;
                vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
                vm.Datas = pageBlog.Item1;
            }

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBlogViewModel viewModel = new();
            var albums = await _AlbumService.SelectAsync();
            viewModel.Albums = new List<CheckBoxModel>();
            if (albums != null)
                foreach (var album in albums)
                    if (album != null)
                        viewModel.Albums.Add(new CheckBoxModel(album.Name, album.ID));
            var categories = await _categoryService.SelectAsync();
            viewModel.Categories = new List<CheckBoxModel>();
            if (categories != null)
                foreach (var category in categories)
                    if (category != null)
                        viewModel.Categories.Add(new CheckBoxModel(category.Name, category.ID));
            var tags = await _tagService.SelectAsync();
            viewModel.Tags = new List<CheckBoxModel>();
            if (tags != null)
                foreach (var tag in tags)
                    if (tag != null)
                        viewModel.Tags.Add(new CheckBoxModel(tag.Name, tag.ID));
            await ReadBindInfo();
            viewModel.Statuses = Enum.GetValues<ModelStatus>();
            viewModel.CreateDate = DateTime.Now;
            viewModel.UpdateDate = DateTime.Now;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBlogViewModel vm)
        {
            var blog = _mapper.Map<Blog>(vm);
            blog.BlogAlbums = new List<BlogAlbum>();
            var albums = vm.Albums?.Where(x => x.Checked).ToList();
            if (albums != null)
                foreach (var item in albums)
                    blog.BlogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = item.Value });
            blog.BlogCategories = new List<BlogCategory>();
            var categories = vm.Categories?.Where(x => x.Checked).ToList();
            if (categories != null)
                foreach (var item in categories)
                    blog.BlogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = item.Value });
            blog.BlogTags = new List<BlogTag>();
            var tags = vm.Tags?.Where(x => x.Checked).ToList();
            if (tags != null)
                foreach (var item in tags)
                    blog.BlogTags.Add(new BlogTag { BlogID = blog.ID, TagID = item.Value });

            await _service.InsertAsync(blog);
            return RedirectToAction(nameof(AdminBlogList));
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(x => x.ID == id);
            return RedirectToAction(nameof(AdminBlogList));
        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var blog = await _service.GetDetailsAsync(id);
            var viewModel = _mapper.Map<UpdateBlogViewModel>(blog);

            var albums = await _AlbumService.SelectAsync();
            viewModel.Albums = new List<CheckBoxModel>();
            if (albums != null)
                foreach (var album in albums)
                    if (album != null)
                        viewModel.Albums.Add(new CheckBoxModel(album.Name, album.ID,
                            blog?.BlogAlbums?.Exists(x => x.AlbumID == album.ID) == true));
            var categories = await _categoryService.SelectAsync();
            viewModel.Categories = new List<CheckBoxModel>();
            if (categories != null)
                foreach (var category in categories)
                    if (category != null)
                        viewModel.Categories.Add(new CheckBoxModel(category.Name, category.ID,
                            blog?.BlogCategories?.Exists(x => x.CategoryID == category.ID) == true));
            var tags = await _tagService.SelectAsync();
            viewModel.Tags = new List<CheckBoxModel>();
            if (tags != null)
                foreach (var tag in tags)
                    if (tag != null)
                        viewModel.Tags.Add(new CheckBoxModel(tag.Name, tag.ID,
                            blog?.BlogTags?.Exists(x => x.TagID == tag.ID) == true));
            await ReadBindInfo();
            viewModel.Statuses = Enum.GetValues<ModelStatus>();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBlogViewModel vm)
        {
            var blog = await _service.GetDetailsAsync(vm.ID);
            if (blog == null) return View();

            _mapper.Map(vm, blog, typeof(UpdateBlogViewModel), typeof(Blog));
            if (blog.BlogAlbums != null)
                blog.BlogAlbums.Clear();
            else
                blog.BlogAlbums = new List<BlogAlbum>();
            var albums = vm.Albums?.Where(x => x.Checked).ToList();
            if (albums != null)
                foreach (var item in albums)
                    blog.BlogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = item.Value });
            if (blog.BlogCategories != null)
                blog.BlogCategories.Clear();
            else
                blog.BlogCategories = new List<BlogCategory>();
            var categories = vm.Categories?.Where(x => x.Checked).ToList();
            if (categories != null)
                foreach (var item in categories)
                    blog.BlogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = item.Value });
            if (blog.BlogTags != null)
                blog.BlogTags.Clear();
            else
                blog.BlogTags = new List<BlogTag>();
            var tags = vm.Tags?.Where(x => x.Checked).ToList();
            if (tags != null)
                foreach (var item in tags)
                    blog.BlogTags.Add(new BlogTag { BlogID = blog.ID, TagID = item.Value });

            await _service.UpdateAsync(blog);
            return RedirectToAction(nameof(AdminBlogList));
        }

        private async Task ReadBindInfo()
        {
            ViewBag.Users = (from x in await _userService.SelectAsync()
                select new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                }).ToList();
        }
    }
}