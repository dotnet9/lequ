using Lequ.IRepository;
using Lequ.IService;
using Lequ.Model.Models;
using System.Linq.Expressions;

namespace Lequ.Service
{
	public class BaseService<T> : IBaseService<T> where T : class, new()
	{
		protected IBaseRepository<T> _repository;

		public BaseService(IBaseRepository<T> repository)
		{
			_repository = repository;
		}

        public async Task<int> InsertAsync(T t)
        {
            return await _repository.InsertAsync(t);
        }

        public async Task<int> UpdateAsync(T t)
        {
            return await _repository.UpdateAsync(t);
        }

        public async Task<int> UpdateAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity)
        {
            return await _repository.UpdateAsync(whereLambda, entity);
        }

        public async Task<int> DeleteAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _repository.DeleteAsync(whereLambda);
        }

        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _repository.IsExistAsync(whereLambda);
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _repository.GetAsync(whereLambda);
        }

        public async Task<List<T>> SelectAsync()
        {
            return await _repository.SelectAsync();
        }

        public async Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda)
        {
            return await _repository.SelectAsync(whereLambda);
        }

        public async Task<Tuple<List<T>, int>> SelectAsync<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, SortDirection sortDirection)
        {
            return await SelectAsync(pageSize, pageIndex, whereLambda, orderByLambda, sortDirection);
        }
    }
}
