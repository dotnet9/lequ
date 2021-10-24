﻿using Lequ.Blog.Model;
using Lequ.Blog.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{ 
    public class CommentRepository : RepositoryBase<Comment, int>, ICommentRepository
    {
        public CommentRepository(Context context) : base(context)
        {
        }
    }
}
