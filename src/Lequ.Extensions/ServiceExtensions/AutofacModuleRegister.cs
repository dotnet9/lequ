using Autofac;
using Autofac.Extras.DynamicProxy;
using Lequ.IRepository;
using Lequ.Repository;
using System.Reflection;

namespace Lequ.Extensions.ServiceExtensions
{
	public class AutofacModuleRegister : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			base.Load(builder);

			var basePath = AppContext.BaseDirectory;

			var servicesDllFile = Path.Combine(basePath, "Lequ.Service.dll");
			var repositoryDllFile = Path.Combine(basePath, "Lequ.Repository.dll");
			if (!File.Exists(servicesDllFile) || !File.Exists(repositoryDllFile))
			{
				throw new Exception($"Please prepare {servicesDllFile} and {repositoryDllFile}");
			}
			builder.RegisterGeneric(typeof(BaseRepository<>)).As(typeof(IBaseRepository<>)).InstancePerDependency();

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
