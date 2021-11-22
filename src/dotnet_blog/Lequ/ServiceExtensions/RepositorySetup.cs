using Lequ.IRepository;
using Lequ.IService;
using Lequ.Repository;
using Lequ.Service;

namespace Lequ.ServiceExtensions;

public static class RepositorySetup
{
	public static void AddRepositorySetup(this IServiceCollection services)
	{
		if (services == null) throw new ArgumentNullException(nameof(services));

		services.AddTransient<IAboutRepository, AboutRepository>();
		services.AddTransient<IAlbumRepository, AlbumRepository>();
		services.AddTransient<IBlogRepository, BlogRepository>();
		services.AddTransient<ICategoryRepository, CategoryRepository>();
		services.AddTransient<ICommentRepository, CommentRepository>();
		services.AddTransient<IContactRepository, ContactRepository>();
		services.AddTransient<ILinkRepository, LinkRepository>();
		services.AddTransient<ISubscribeEmailRepository, SubscribeEmailRepository>();
		services.AddTransient<ITagRepository, TagRepository>();
		services.AddTransient<IUserRepository, UserRepository>();

		services.AddTransient<IAboutService, AboutService>();
		services.AddTransient<IAlbumService, AlbumService>();
		services.AddTransient<IBlogService, BlogService>();
		services.AddTransient<ICategoryService, CategoryService>();
		services.AddTransient<ICommentService, CommentService>();
		services.AddTransient<IContactService, ContactService>();
		services.AddTransient<ILinkService, LinkService>();
		services.AddTransient<ISubscribeEmailService, SubscribeEmailService>();
		services.AddTransient<ITagService, TagService>();
		services.AddTransient<IUserService, UserService>();
	}
}