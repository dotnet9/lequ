using Lequ.Blog.Extensions.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Lequ.Blog.Extensions.ServiceExtensions
{
	public static class AutoMapperSetup
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if (services== null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.AddAutoMapper(typeof(AutoMapperConfig));
		}
	}
}
