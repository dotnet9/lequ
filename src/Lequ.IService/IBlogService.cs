using Lequ.Model.Models;
using System.Linq.Expressions;

namespace Lequ.IService
{
    public interface IBlogService : IBaseService<Blog>
    {
        Task<List<Blog>> ListDetailsAsync();
        Task<Tuple<List<Blog>, int>> ListDetailsAsync(Expression<Func<Blog, bool>> whereLambda, int pageIndex, int pageSize);
        Task<Blog?> GetDetailsAsync(int id);
    }
}
