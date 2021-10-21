using System;
using Lequ.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public class BlogDBContext:DbContext
    {
        public DbSet<CategoryInfo> CategoryInfos { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<PostInfo> PostInfos { get; set; }

        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }
    }
}

