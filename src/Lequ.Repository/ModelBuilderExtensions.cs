﻿using Lequ.Model.Models;
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
				Status = ModelStatus.Normal,
				CreateBy = 1,
				CreateDate = DateTime.Now
			};
			modelBuilder.Entity<Admin>().HasData(adminUser);

			var authorUser = new User
			{
				ID = 1,
				Name = "Lequ.CO",
				About = "Coder",
				Status = ModelStatus.Normal,
				CreateBy = adminUser.ID,
				CreateDate = DateTime.Now
			};
			modelBuilder.Entity<User>().HasData(authorUser);

			var blogCategories = new List<BlogCategory>();

			var blogTags = new List<BlogTag>();

			var blogAlbums = new List<BlogAlbum>();

			var categoryCSharp = new Category { ID = 1, Name = "C#", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			var categoryCPlusPlus = new Category { ID = 2, Name = "C++", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Category>().HasData(categoryCSharp, categoryCPlusPlus);


			var tagCSharp = new Tag { ID = 1, Name = "C#", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			var tagCPlusPlus = new Tag { ID = 2, Name = "C++", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Tag>().HasData(tagCSharp, tagCPlusPlus);


			var albumCSharp = new Album { ID = 1, Name = "C#", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			var albumCPlusPlus = new Album { ID = 2, Name = "C++", Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now };
			modelBuilder.Entity<Album>().HasData(albumCSharp, albumCPlusPlus);

			List<Blog> blogs = new List<Blog>();
			for (int i = 0; i < 30; i++)
			{
				var blog = new Blog
				{
					ID = i + 1,
					Title = $"WPF值得注意的IsHitTestVisible {i}",
					Content = $"{i} {GetBlogContent()}",
					Image = "/Front/images/img_1.jpg",
					Status = ModelStatus.Normal,
					UserID = authorUser.ID,
					CreateBy = authorUser.ID,
					CreateDate = DateTime.Now,
				};

				blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCSharp.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });
				blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCPlusPlus.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });

				blogTags.Add(new BlogTag { BlogID = blog.ID, TagID = tagCSharp.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });
				blogTags.Add(new BlogTag { BlogID = blog.ID, TagID = tagCPlusPlus.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });

				blogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = albumCSharp.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });
				blogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = albumCPlusPlus.ID, Status = ModelStatus.Normal, CreateBy = authorUser.ID, CreateDate = DateTime.Now });

				blogs.Add(blog);
			}
			modelBuilder.Entity<Blog>().HasData(blogs);

			modelBuilder.Entity<BlogCategory>().HasData(blogCategories);

			modelBuilder.Entity<BlogTag>().HasData(blogTags);

			modelBuilder.Entity<BlogAlbum>().HasData(blogAlbums);
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
