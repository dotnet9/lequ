﻿using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;

namespace Lequ.Service
{
    public class CommentService : BaseService<Comment>, ICommentService
    {
        public CommentService(ICommentRepository repository) : base(repository)
        {
        }
    }
}