using Lequ.Blog.IRepository;
using Lequ.Blog.IService;
using Lequ.Blog.Repository;
using Lequ.Blog.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Context>(option => {
    option.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Lequ.Blog;integrated security=true;");
});
builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();