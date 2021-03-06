using Lequ.GlobalVar;
using Lequ.Models;
using Lequ.ViewModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Lequ.Repository;

public static class ModelBuilderExtensions
{
	public static void Seed(this ModelBuilder modelBuilder)
	{
		Random random = new(DateTime.Now.Millisecond);
		if (!File.Exists(ConfigurationConsts.ABOUT_PATH) || !File.Exists(ConfigurationConsts.BLOG_BASE_PATH) ||
		    !Directory.Exists(ConfigurationConsts.BLOG_POST_PATH)) return;

		var baseInfo = JsonConvert.DeserializeObject<BlogBaseDto>(File.ReadAllText(ConfigurationConsts.BLOG_BASE_PATH));

		var seedBlogs = new List<BlogSeedDto>();
		foreach (var blogInfoPath in Directory.GetFiles(ConfigurationConsts.BLOG_POST_PATH, "*.info",
			         SearchOption.AllDirectories))
		{
			var blogInfoText = File.ReadAllText(blogInfoPath);
			var blogInfoDto = JsonConvert.DeserializeObject<BlogSeedDto>(blogInfoText);
			blogInfoDto!.Content = File.ReadAllText(blogInfoPath.Replace("info", "md"));
			seedBlogs.Add(blogInfoDto);
		}

		var user = new User
		{
			ID = 1,
			RoleEnum = UserRoleEnum.User,
			Name = "沙漠尽头的狼",
			Account = "Dotnet9",
			Password = "Dotnet9",
			Title = "码农",
			About =
				"你好，我是本站（https://Dotnet9.com）站长“沙漠尽头的狼”。本人从事dotnet开发已有10年，建此站目的在于分享以dotnet为主的技术类文章，希望以此平台与更多的程序员朋友交流技术，祝愿dotnet社区发展越来越好。",
			AboutShort =
				"89年Dotnet程序猿一枚，C#高级工程师， 目前从事C/S开发工作。",
			Address = "Chendu. China",
			PhoneNumber = "169888322",
			Email = "632871194@qq.com",
			Image = "/wolf.jpg",
			StatusEnum = ModelStatus.Normal,
			CreateDate = DateTime.Now
		};
		modelBuilder.Entity<User>().HasData(user);

		var lstCategories = new List<Category>();
		var blogCategories = new List<BlogCategory>();
		var lstTags = new List<Tag>();
		var blogTags = new List<BlogTag>();
		var lstAlbums = new List<Album>();
		var blogAlbums = new List<BlogAlbum>();

		if (baseInfo?.Albums != null)
			lstAlbums.AddRange(baseInfo.Albums.Select((t, i) => new Album
			{
				ID = i + 1,
				Name = t.Name,
				Cover = t.Cover,
				StatusEnum = ModelStatus.Normal,
				CreateUserID = user.ID,
				CreateDate = DateTime.Now
			}));

		List<Comment> comments = new();

		List<Blog> blogs = new();
		var sortBlogs = (from b in seedBlogs orderby b.CreateDate select b)
			.ToList();
		for (var i = 0; i < sortBlogs.Count; i++)
		{
			var seedBlog = sortBlogs[i];
			var blog = new Blog
			{
				ID = i + 1,
				Title = seedBlog.Title,
				BriefDescription = seedBlog.BriefDescription,
				Cover = seedBlog.Cover,
				InBanner = seedBlog.InBanner,
				Content = seedBlog.Content,
				BlogCopyrightTypeEnum = (CopyrightType)Enum.Parse(typeof(CopyrightType),
					seedBlog.CopyrightType ??= CopyrightType.Default.ToString()),
				Original = seedBlog.Original,
				OriginalAvatar = $"/imgs/authors/p{random.Next(1, 26)}.png",
				OriginalLink = seedBlog.OriginalLink,
				Rating = random.Next(100),
				StatusEnum = ModelStatus.Normal,
				CreateUserID = user.ID,
				CreateDate = seedBlog.CreateDate
			};

			if (seedBlog.Categories != null && seedBlog.Categories.Any())
				for (var j = 0; j < seedBlog.Categories.Count(); j++)
				{
					var categoryName = seedBlog.Categories[j];
					var existCategory = lstCategories.FirstOrDefault(cu => cu.Name == categoryName);
					if (existCategory == null)
					{
						existCategory = new Category
						{
							ID = blogCategories.Count + 1,
							Name = categoryName,
							StatusEnum = ModelStatus.Normal,
							CreateUserID = user.ID,
							CreateDate = seedBlog.CreateDate
						};
						lstCategories.Add(existCategory);
					}

					blogCategories.Add(new BlogCategory
					{
						BlogID = blog.ID,
						CategoryID = existCategory.ID,
						StatusEnum = ModelStatus.Normal,
						CreateUserID = user.ID,
						CreateDate = seedBlog.CreateDate
					});
				}

			if (seedBlog.Tags != null && seedBlog.Tags.Any())
				for (var j = 0; j < seedBlog.Tags.Count(); j++)
				{
					var tagName = seedBlog.Tags[j];
					var existTag = lstTags.FirstOrDefault(cu => cu.Name == tagName);
					if (existTag == null)
					{
						existTag = new Tag
						{
							ID = lstTags.Count + 1,
							Name = tagName,
							StatusEnum = ModelStatus.Normal,
							CreateUserID = user.ID,
							CreateDate = seedBlog.CreateDate
						};
						lstTags.Add(existTag);
					}

					blogTags.Add(new BlogTag
					{
						BlogID = blog.ID,
						TagID = existTag.ID,
						StatusEnum = ModelStatus.Normal,
						CreateUserID = user.ID,
						CreateDate = seedBlog.CreateDate
					});
				}

			if (seedBlog.Albums != null && seedBlog.Albums.Any())
				for (var j = 0; j < seedBlog.Albums.Count(); j++)
				{
					var albumName = seedBlog.Albums[j];
					var existAlbum = lstAlbums.FirstOrDefault(cu => cu.Name == albumName);
					if (existAlbum == null)
					{
						existAlbum = new Album
						{
							ID = lstAlbums.Count + 1,
							Name = albumName,
							StatusEnum = ModelStatus.Normal,
							CreateUserID = user.ID,
							CreateDate = seedBlog.CreateDate
						};
						lstAlbums.Add(existAlbum);
					}

					blogAlbums.Add(new BlogAlbum
					{
						BlogID = blog.ID,
						AlbumID = existAlbum.ID,
						StatusEnum = ModelStatus.Normal,
						CreateUserID = user.ID,
						CreateDate = seedBlog.CreateDate
					});
				}

			blogs.Add(blog);

			comments.Add(new Comment
			{
				ID = i + 1,
				BlogID = blog.ID,
				Content =
					"该项目一直在更新中，数据库可能会随时被清空，如有建议请先在Dotnet9公众号留言，这里留言可能随时都会消失哦！！！",
				StatusEnum = ModelStatus.Normal,
				CreateUserID = 1,
				CreateDate = seedBlog.CreateDate
			});
		}

		modelBuilder.Entity<Category>().HasData(lstCategories);
		modelBuilder.Entity<Tag>().HasData(lstTags);
		modelBuilder.Entity<Album>().HasData(lstAlbums);

		modelBuilder.Entity<Blog>().HasData(blogs);

		modelBuilder.Entity<BlogCategory>().HasData(blogCategories);

		modelBuilder.Entity<BlogTag>().HasData(blogTags);

		modelBuilder.Entity<BlogAlbum>().HasData(blogAlbums);

		modelBuilder.Entity<Comment>().HasData(comments);

		modelBuilder.Entity<About>().HasData(new About
		{
			ID = 1,
			Details = File.ReadAllText(ConfigurationConsts.ABOUT_PATH)
		});

		modelBuilder.Entity<Link>().HasData(
			new Link
			{
				ID = 1,
				Index = 1,
				Name = "Murat Yücedağ",
				Url = "https://www.youtube.com/channel/UCbkbOlw8snP93RJ2BhH44Qw",
				Description =
					"Ücretsiz olarak çektiğim yazılım eğitim videolarını paylaşmak amacıyla oluşturduğum kanaldır.Ücretsiz Eğitim Videosu Hedefi: 3000 :)Misyonumun fikir babası İsmail Hakkı Tonguç ve Hasan Ali Yücel'dir. Onlardan aldığım meşaleyi bizden sonrakilere taşımak gayesindeyim. Bunu da lisans eğitimimde aldığım mühendislik disiplinini eğitmenlikle harmanlayarak yazılımda Türkçe kaynağın arttırılması yolunda çalışmalarımı \"her geçen gün bir önceki günden daha dolu olmalı\" ideali ile sürdürmekteyim.",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 2,
				Index = 2,
				Name = "老张的哲学",
				Url = "https://www.cnblogs.com/laozhang-is-phi/",
				Description = "博客园大拿",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 3,
				Index = 3,
				Name = "懒得勤快",
				Url = "https://masuit.org/",
				Description = "各种资源分享站",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 4,
				Index = 4,
				Name = "Garfield-加菲的博客",
				Url = "http://www.randyfield.cn/",
				Description = "技术爱好者",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 5,
				Index = 5,
				Name = "青城",
				Url = "https://qingchengblog.com/",
				Description = "技术爱好者",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 6,
				Index = 6,
				Name = "江湖人士",
				Url = "https://jhrs.com/",
				Description =
					"建站分享站",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			},
			new Link
			{
				ID = 7,
				Index = 7,
				Name = "Code Life",
				Url = "https://znlive.com/",
				Description =
					"Coding life is a website about programmer stories. Here, we will share information about how to code, how newcomers learn to code, coding challenges, coding games and IT industry news.",
				StatusEnum = ModelStatus.Normal,
				CreateDate = DateTime.Now
			}
		);
	}
}