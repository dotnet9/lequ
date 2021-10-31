using Lequ.Extensions.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Lequ.Extensions.ServiceExtensions
{
    public static class AutoMapperSetup
	{
		public static void AddAutoMapperSetup(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException(nameof(services));
			}

			services.AddAutoMapper(typeof(AutoMapperConfig));
		}
	}
}
