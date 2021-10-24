namespace Lequ.Blog.IRepository
{
    public interface IRepositoryBase<T, TID>
    {
        Task<bool> Add(T t);
        Task<bool> Remove(T t);
        Task<bool> Update(T t);
        Task<IEnumerable<T>> GetAll();
        Task<T?> Get(TID id);
    }
}
