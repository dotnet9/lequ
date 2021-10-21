﻿using System;
using Lequ.IRepository;
using Lequ.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class PostInfoRepository : RepositoryBase<PostInfo, int>, IPostInfoRepository
    {
        public PostInfoRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}