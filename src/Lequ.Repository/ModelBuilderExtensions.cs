using Lequ.Model;
using Lequ.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            var adminUser = new Admin
            {
                ID = 1,
                UserName = "admin",
                Password = "admin",
                Status = ModelStatus.Normal,
                CreateUserID = 1,
                CreateDate = DateTime.Now
            };
            modelBuilder.Entity<Admin>().HasData(adminUser);

            var lstUsers = new List<User>();
            for (int i = 0; i < 100; i++)
            {
                lstUsers.Add(new User
                {
                    ID = i + 1,
                    Name = $"User name {i}",
                    Account = $"User{i}",
                    Password = "222222",
                    Title = "Coder",
                    About = "你好，我是本站（https://dotnet9.com）站长Dotnet9小编，曾用网名“沙漠之狐”、“沙漠尽头的狼”。本人从事dotnet开发近10年，建此站目的在于分享以dotnet为主的技术类文章，希望以此平台与更多的程序员朋友交流技术，祝愿dotnet社区发展越来越好。 89年Dotnet程序猿一枚，C#高级工程师， 目前从事B/S开发工作。",
                    AboutShort = "89年C# Coder,从事dotnet开发近10年，建此站目的在于分享以dotnet为主的技术类文章，希望以此平台与更多的程序员朋友交流技术，祝愿dotnet社区发展越来越好。",
                    Address = "Chendu. China",
                    PhoneNumber = "169888322",
                    Email = "632871194@qq.com",
                    Image = $"/Front/images/person_{random.Next(5)}.jpg",
                    Status = ModelStatus.Normal,
                    CreateUserID = adminUser.ID,
                    CreateDate = DateTime.Now
                });
            }
            modelBuilder.Entity<User>().HasData(lstUsers);

            var blogCategories = new List<BlogCategory>();

            var blogTags = new List<BlogTag>();

            var blogAlbums = new List<BlogAlbum>();

            var categoryCSharp = new Category { ID = 1, Name = "C#", Description = "B/S,C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            var categoryCPlusPlus = new Category { ID = 2, Name = "C++", Description = "C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            modelBuilder.Entity<Category>().HasData(categoryCSharp, categoryCPlusPlus);


            var tagCSharp = new Tag { ID = 1, Name = "C#", Description = "B/S,C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            var tagCPlusPlus = new Tag { ID = 2, Name = "C++", Description = "C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            modelBuilder.Entity<Tag>().HasData(tagCSharp, tagCPlusPlus);


            var albumCSharp = new Album { ID = 1, Name = "C#", Description = "B/S,C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            var albumCPlusPlus = new Album { ID = 2, Name = "C++", Description = "C/S, App", Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now };
            modelBuilder.Entity<Album>().HasData(albumCSharp, albumCPlusPlus);

            List<Comment> comments = new List<Comment>();

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
                    CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID,
                    CreateDate = DateTime.Now,
                };

                blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCSharp.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });
                blogCategories.Add(new BlogCategory { BlogID = blog.ID, CategoryID = categoryCPlusPlus.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });

                blogTags.Add(new BlogTag { BlogID = blog.ID, TagID = tagCSharp.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });
                blogTags.Add(new BlogTag { BlogID = blog.ID, TagID = tagCPlusPlus.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });

                blogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = albumCSharp.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });
                blogAlbums.Add(new BlogAlbum { BlogID = blog.ID, AlbumID = albumCPlusPlus.ID, Status = ModelStatus.Normal, CreateUserID = lstUsers[random.Next(lstUsers.Count)].ID, CreateDate = DateTime.Now });

                blogs.Add(blog);

                comments.Add(new Comment { ID = i + 1, BlogID = blog.ID, Content = "This blog is very good , I like it, thank you!", CreateUserID = 1, CreateDate = DateTime.Now });
            }
            modelBuilder.Entity<Blog>().HasData(blogs);

            modelBuilder.Entity<BlogCategory>().HasData(blogCategories);

            modelBuilder.Entity<BlogTag>().HasData(blogTags);

            modelBuilder.Entity<BlogAlbum>().HasData(blogAlbums);

            modelBuilder.Entity<Comment>().HasData(comments);

            modelBuilder.Entity<About>().HasData(new About { ID = 1, Details1 = "优美胜于丑陋。\r\n 明了胜于晦涩。\r\n 简洁胜于复杂。\r\n 复杂胜于凌乱。\r\n 扁平胜于嵌套。\r\n 宽松胜于紧凑。\r\n 可读性很重要。" });
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
