using Entites.Abstract;
using System.Linq.Expressions;

namespace DAL.Repository.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        Task<int> Insert(T input);

        Task<int> Update(T input);

        Task<int> Delete(T input);

        Task<T?> GetById(int id);

        Task<ICollection<T>>? GetAll(Expression<Func<T , bool>>? filter = null);

        Task<IQueryable<T>>? GetAllInclude(Expression<Func<T , bool>>? filter = null , params Expression<Func<T , object>>[]? include);
    }
}