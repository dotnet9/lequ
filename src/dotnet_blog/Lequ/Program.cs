using FluentValidation.AspNetCore;
using Lequ.GlobalVar;
using Lequ.ServiceExtensions;
using Markdig;
using Markdig.Extensions.AutoIdentifiers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.FileProviders;
using Westwind.AspNetCore.Markdown;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(10);
	options.Cookie.HttpOnly = true;
	options.Cookie.IsEssential = true;
});

builder.Services.AddLocalization(o => o.ResourcesPath = ConfigurationConsts.RESOURCES_PATH);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddFluentValidationSetup();

builder.Services.AddMarkdown(config =>
{
	// Create custom MarkdigPipeline 
	// using MarkDig; for extension methods
	config.ConfigureMarkdigPipeline = builder =>
	{
		// optional Tag BlackList
		config.HtmlTagBlackList = "script|iframe|object|embed|form"; // default
		builder.UseEmphasisExtras()
			.UsePipeTables()
			.UseGridTables()
			.UseAutoIdentifiers(AutoIdentifierOptions.GitHub) // Headers get id="name" 
			.UseAutoLinks() // URLs are parsed into anchors
			.UseAbbreviations()
			.UseYamlFrontMatter()
			.UseEmojiAndSmiley()
			.UseListExtras()
			.UseFigures()
			.UseTaskLists()
			.UseCustomContainers()
			.UseGenericAttributes();
	};
});

builder.Services.AddMvc(config =>
	{
		var policy = new AuthorizationPolicyBuilder()
			.RequireAuthenticatedUser()
			.Build();
		config.Filters.Add(new AuthorizeFilter(policy));
	})
	.AddFluentValidation()
	.AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
	.AddDataAnnotationsLocalization()
	.AddApplicationPart(typeof(MarkdownPageProcessorMiddleware).Assembly);

var supportedCultures = new[] { "en-US", "zh-Hans", "zh-Hant", "ja" };
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
	options.SetDefaultCulture(supportedCultures[0])
		.AddSupportedCultures(supportedCultures)
		.AddSupportedUICultures(supportedCultures);
});

builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(x => x.LoginPath = "/Login/UserLogin");

builder.Services.AddDbSetup(builder.Configuration.GetConnectionString("DefaultConnection"), builder.Environment.EnvironmentName);
builder.Services.AddAutoMapperSetup();
builder.Services.AddRepositorySetup();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}");

app.UseHttpsRedirection();

app.UseMarkdown();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
	FileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory())
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
	.AddSupportedCultures(supportedCultures)
	.AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
	"default",
	"{controller=Home}/{action=Index}/{id?}");

app.Run();