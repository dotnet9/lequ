using System;
using Lequ.Model;
using Microsoft.EntityFrameworkCore;

namespace Lequ.Repository
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            UserInfo user = new UserInfo {
                ID=1,
                Name="admin",
                Memo="administraor",
                Account="admin",
                Password="000000",
            };
            modelBuilder.Entity<UserInfo>().HasData(user);
            CategoryInfo csharp = new CategoryInfo
            {
                ID=1,
                Title="C#",
                Content=".NET Web API, ASP.NET Core, WPF\\Winform",
                CreateUserID = user.ID
            };
            modelBuilder.Entity<CategoryInfo>().HasData(csharp);
            PostInfo post = new PostInfo {
                Title = "Create WPF Project",
                Content = "Use Visual Studio to create a WPF project",
                CategoryID = csharp.ID,
                CreateUserID = user.ID,
            };
        }
    }
}

