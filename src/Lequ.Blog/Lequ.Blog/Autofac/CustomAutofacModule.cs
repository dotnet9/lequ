using Autofac;
using Lequ.Blog.Repository;

namespace Lequ.Blog.Autofac
{
    public class CustomAutofacModule:Module
    {
        public CustomAutofacModule(ContainerBuilder builder)
        {

        }
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }
    }
}
