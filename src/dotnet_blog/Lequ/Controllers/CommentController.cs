using AutoMapper;
using Lequ.GlobalVar;
using Lequ.IService;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Lequ.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _service;
        private readonly IUserService _userService;

        public CommentController(ICommentService service, IUserService userService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Leave(Comment comment)
        {
            // TODO
            comment.CreateUserID = 1;
            comment.CreateDate = DateTime.Now;
            comment.UpdateDate = DateTime.Now;
            comment.StatusEnum = ModelStatus.Check;
            await _service.InsertAsync(comment);
            return RedirectToAction("Details", "Blog", new { id = comment.BlogID });
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int blogID, int commentID, int userID, string content)
        {
            // TODO
            var comment = new Comment();
            comment.BlogID = blogID;
            comment.CreateUserID = userID;
            comment.CreateDate = DateTime.Now;
            comment.UpdateDate = DateTime.Now;
            comment.StatusEnum = ModelStatus.Normal;
            comment.ParentID = commentID;
            comment.Content = content;
            await _service.InsertAsync(comment);
            return Json("");
        }

        public async Task<IActionResult> AdminCommentList(ModelStatus? status = null, int page = 1)
        {
            Expression<Func<Comment, bool>> whereLambda;
            if (status == null)
                whereLambda = x => x.ID > 0;
            else
                whereLambda = x => x.Status == (int)status;
            var pageComment = await _service.SelectAsync(pageSize: GlobalVars.PAGINATION_SMALL_PAGE_SIZE, pageIndex: page,
                whereLambda, orderByLambda: x => x.UpdateDate, sortDirection: SortDirection.Descending, x => x.Blog);
            var vm = new PagingViewModelBase<CommentDto>();
            vm.Status = status;
            if (pageComment != null && pageComment.Item1.Count > 0)
            {
                var commentVM = _mapper.Map<List<CommentDto>>(pageComment.Item1);
                vm.PageCount = (pageComment.Item2 + GlobalVars.PAGINATION_SMALL_PAGE_SIZE - 1) / GlobalVars.PAGINATION_SMALL_PAGE_SIZE;
                vm.PageIndex = page < 1 ? 1 : page;
                vm.PageIndex = vm.PageIndex > vm.PageCount ? vm.PageCount : vm.PageIndex;
                vm.Datas = commentVM;


                var users = await _userService.SelectAsync();
                if (users != null)
                    commentVM.ForEach(cu =>
                    {
                        if (cu.CreateUserID.HasValue)
                            cu.CreateUser = users.FirstOrDefault(x => x.ID == cu.CreateUserID.Value);
                    });
            }

            return View(vm);
        }

        public async Task<IActionResult> AdminBlogCommentList(int blogID)
        {
            var comments = await _service.SelectAsync(whereLambda: x => x.BlogID == blogID,
                orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending, x => x.Blog);
            var users = await _userService.SelectAsync();
            if (comments != null && users != null)
                comments.ForEach(cu =>
                {
                    if (cu.CreateUserID.HasValue)
                        cu.CreateUser = users.FirstOrDefault(x => x.ID == cu.CreateUserID.Value);
                });
            return View(comments);
        }

        public async Task<IActionResult> Delete(int blogID, int id)
        {
            await _service.DeleteAsync(x => x.ID == id);
            return RedirectToAction(nameof(AdminCommentList), new { blogID });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeStatus(int id, int status)
        {
            var comment = await _service.GetAsync(x => x.ID == id);
            comment.Status = status;
            await _service.UpdateAsync(comment);
            return Json(comment);
        }
    }
}