using AutoMapper;
using Lequ.Common;
using Lequ.IService;
using Lequ.Model;
using Lequ.Model.Models;
using Lequ.Model.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

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
            comment.UpdateDate= DateTime.Now;
            comment.Status = ModelStatus.Normal;
            await _service.InsertAsync(comment);
            return RedirectToAction("Details", "Blog", new { id = comment.BlogID });
        }

        public async Task<IActionResult> AdminCommentList(int blogID)
        {
            var comments = await _service.SelectAsync(whereLambda: x => x.BlogID == blogID, orderByLambda: x => x.CreateDate, sortDirection: SortDirection.Descending, x => x.Blog);
            var users = await _userService.SelectAsync();
            if (comments != null && users != null)
            {
                comments.ForEach(cu =>
                {
                    if (cu.CreateUserID.HasValue)
                    {
                        cu.CreateUser = users.FirstOrDefault(x => x.ID == cu.CreateUserID.Value);
                    }
                });
            }
            return View(comments);
        }

        public async Task<IActionResult> Delete(int blogID, int id)
        {
            await _service.DeleteAsync(x => x.ID == id);
            return RedirectToAction(nameof(AdminCommentList), new { blogID });
        }
    }
}
