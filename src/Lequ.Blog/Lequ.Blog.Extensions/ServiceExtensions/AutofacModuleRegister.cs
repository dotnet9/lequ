using Autofac;
using Lequ.Blog.IRepository;
using Lequ.Blog.Repository;
using System.Reflection;
using Autofac.Extras.DynamicProxy;

namespace Lequ.Blog.Extensions.ServiceExtensions
{
	public class AutofacModuleRegister: Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			var basePath = AppContext.BaseDirectory;

			var servicesDllFile = Path.Combine(basePath, "Lequ.Blog.Service.dll");
			var repositoryDllFile = Path.Combine(basePath, "Lequ.Blog.Repository.dll");
			if(!File.Exists(servicesDllFile) || !File.Exists(repositoryDllFile))
			{
				throw new Exception($"Please prepare {servicesDllFile} and {repositoryDllFile}");
			}
			builder.RegisterGeneric(typeof(RepositoryBase<,>)).As(typeof(IRepositoryBase<,>)).InstancePerDependency();

			var assemblyServices = Assembly.LoadFrom(servicesDllFile);
			builder.RegisterAssemblyTypes(assemblyServices)
				.AsImplementedInterfaces()
				.InstancePerDependency()
				.PropertiesAutowired()
				.EnableClassInterceptors();

			var assemblyRepositories = Assembly.LoadFrom(repositoryDllFile);
			builder.RegisterAssemblyTypes(assemblyRepositories)
				.AsImplementedInterfaces()
				.InstancePerDependency()
				.PropertiesAutowired();
		}
	}
}
