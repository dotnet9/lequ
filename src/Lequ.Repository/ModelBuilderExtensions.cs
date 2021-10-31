using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var adminUser = new Admin
			{
				ID = 1,
				UserName = "admin",
				Password = "admin",
				Status = true,
				CreateBy = 1,
				CreateDate = DateTime.Now
			};
			modelBuilder.Entity<Admin>().HasData(adminUser);

			var authorUser = new Author
			{
				ID = 1,
				Name = "Lequ.CO",
				About = "Coder",
				Status = true,
				CreateBy = adminUser.ID,
				CreateDate = DateTime.Now
			};
			modelBuilder.Entity<Author>().HasData(authorUser);

			var category = new Category { ID = 1, Name = "C#", Status = true, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Category>().HasData(category);

			List<Model.Models.Blog> blogs = new List<Model.Models.Blog>();
			for (int i = 0; i < 20; i++)
			{
				blogs.Add(new Blog
				{
					ID = i + 1,
					Title = $"test title {i}",
					Content = $"test content {i}",
					Status = true,
					AuthorID = authorUser.ID,
					CreateBy = authorUser.ID,
					CreateDate = DateTime.Now,
				});
			}
			modelBuilder.Entity<Model.Models.Blog>().HasData(blogs);
		}
	}
}
