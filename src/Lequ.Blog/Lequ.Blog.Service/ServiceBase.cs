using Lequ.Blog.IRepository;
using Lequ.Blog.IService;
using System.Linq.Expressions;

namespace Lequ.Blog.Service
{
    public class ServiceBase<T, TID> : IServiceBase<T, TID> where T : class, new()
    {
        protected IRepositoryBase<T, TID> repositoryBase;

        public async Task<bool> Add(T t)
        {
            return await repositoryBase.Add(t);
        }

        public async Task<T?> Get(TID id)
        {
            return await repositoryBase.Get(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await repositoryBase.GetAll();
        }
        public async Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
		{
            return await repositoryBase.List(predicate);
		}

        public async Task<bool> Remove(T t)
        {
            return await repositoryBase.Remove(t);
        }

        public async Task<bool> Update(T t)
        {
            return await repositoryBase.Update(t);
        }
    }
}
