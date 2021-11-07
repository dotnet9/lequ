﻿using AutoMapper;
using Lequ.IService;
using Lequ.Model.ViewModels.Comments;
using Microsoft.AspNetCore.Mvc;

namespace Lequ.ViewComponents.Comment
{
    public class CommentList : ViewComponent
    {
        private readonly ICommentService _service;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public CommentList(ICommentService service, IUserService userService, IMapper mapper)
        {
            _service = service;
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogID)
        {
            var comments = await _service.SelectAsync(x => x.BlogID == blogID, x => x.Parent);
            var vm = new BlogCommentListViewModel();
            vm.BlogID = blogID;
            if (comments != null && comments.Count > 0)
            {
                vm.Comments = _mapper.Map<List<CommentDto>>(comments);
                var users = await _userService.SelectAsync();
                for (int i = 0; i < vm.Comments.Count; i++)
                {
                    var item = vm.Comments[i];
                    item.Floor = (i + 1);
                    if (users != null)
                    {
                        item.CreateUser = users.FirstOrDefault(x => x.ID == item.CreateUserID);
                    }
                }
                vm.Comments.ForEach(x =>
                {
                    if (x.Parent != null)
                    {
                        x.Parent = vm.Comments.Find(c => c.ID == x.Parent.ID);
                    }
                });
            }
            return View(vm);
        }
    }
}