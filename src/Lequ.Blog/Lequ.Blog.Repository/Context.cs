using Lequ.Blog.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Blog.Repository
{
    public class Context:DbContext
    {
        public DbSet<About>? Abouts { get; set; }
        public DbSet<Lequ.Blog.Entity.Blog>? Blogs { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<UserInfo>? UserInfos { get; set; }

        public Context(DbContextOptions<Context> options): base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
		}
    }
}
