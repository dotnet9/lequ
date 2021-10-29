using Lequ.Blog.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lequ.Blog.Repository
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var adminUser = new UserInfo
			{
				ID = 1,
				Name = "Lequ.CO",
				Account = "Lequ.CO",
				About = "Coder",
				Email = "1012434131@qq.com",
				Password = "Lequ.CO",
				Status = true,
				CreateBy = 1,
				CreateDate = DateTime.Now
			};
			modelBuilder.Entity<UserInfo>().HasData(adminUser);

			var category = new Category { ID = 1, Name = "C#", Status = true, CreateBy = adminUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Category>().HasData(category);

			List<Model.Models.Blog> blogs = new List<Model.Models.Blog>();
			for (int i = 0; i < 20; i++)
			{
				blogs.Add(new Model.Models.Blog
				{
					ID = i + 1,
					Title = $"test title {i}",
					Content = $"test content {i}",
					Status = true,
					CreateBy = adminUser.ID,
					CreateDate = DateTime.Now,
				});
			}
			modelBuilder.Entity<Model.Models.Blog>().HasData(blogs);
		}
	}
}
