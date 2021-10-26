using AutoMapper;

namespace Lequ.Blog.Extensions.AutoMapper
{
	public class AutoMapperConfig
	{
		public static MapperConfiguration RegisterMappings()
		{
			return new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new CustomProfile());
			});
		}
	}
}
