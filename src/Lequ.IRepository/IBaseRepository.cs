﻿using Lequ.Model.Models;
using System.Linq.Expressions;

namespace Lequ.IRepository
{
    public interface IBaseRepository<T>
    {
        Task<int> InsertAsync(T t);

        Task<int> UpdateAsync(T t);

        Task<int> UpdateAsync(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> entity);

        Task<int> DeleteAsync(Expression<Func<T, bool>> whereLambda);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> whereLambda);

        Task<T?> GetAsync(Expression<Func<T, bool>> whereLambda);

        Task<List<T>> SelectAsync();

        Task<List<T>> SelectAsync(Expression<Func<T, bool>> whereLambda);

        Task<Tuple<List<T>, int>> SelectAsync<S>(int pageSize, int pageIndex, Expression<Func<T, bool>> whereLambda, Expression<Func<T, S>> orderByLambda, SortDirection sortDirection);
    }
}