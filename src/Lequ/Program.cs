using Autofac;
using Autofac.Extensions.DependencyInjection;
using Lequ.Extensions.ServiceExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModuleRegister()));

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//        .RequireAuthenticatedUser()
//        .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//});
builder.Services.AddMvc();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(x => x.LoginPath = "/Login/Index");
builder.Services.AddDbSetup(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddAutoMapperSetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
//app.UseHttpsRedirection();

app.UseStaticFiles();

//app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
