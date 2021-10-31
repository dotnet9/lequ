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

			var blogCategories = new List<BlogCategory>();

			var categoryCSharp = new Category { ID = 1, Name = "C#", Status = true, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			var categoryCPlusPlus = new Category { ID = 2, Name = "C++", Status = true, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Category>().HasData(categoryCSharp, categoryCPlusPlus);

			List<Blog> blogs = new List<Blog>();
			for (int i = 0; i < 20; i++)
			{
				var blog = new Blog
				{
					ID = i + 1,
					Title = $"How to handle Many-To-Many in Entity Framework Core {i}",
					Content = $"{i} {GetBlogContent()}",
					Image = "/Front/images/img_1.jpg",
					Status = true,
					CreateBy = authorUser.ID,
					CreateDate = DateTime.Now,
				};
				blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCSharp.ID, Status = true, CreateBy = authorUser.ID, CreateDate = DateTime.Now });
				blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCPlusPlus.ID, Status = true, CreateBy = authorUser.ID, CreateDate = DateTime.Now });
				blogs.Add(blog);
			}
			modelBuilder.Entity<Blog>().HasData(blogs);

			modelBuilder.Entity<BlogCategory>().HasData(blogCategories);
		}

		private static string? blogContent = null;
		private static string GetBlogContent()
		{
			if (blogContent != null)
			{
				return blogContent;
			}
			blogContent = File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}TestBlogContent.txt");
			return blogContent;
		}
	}
}
