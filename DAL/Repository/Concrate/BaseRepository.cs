using DAL.Contexts;
using DAL.Repository.Abstract;
using Entites.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        public SqlDbContext Context { get; set; }

        public BaseRepository()
        {
            Context = new SqlDbContext();
        }

        public async Task<int> Delete(T input)
        {
            Context.Set<T>().Remove(input);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Insert(T input)
        {
            await Context.Set<T>().AddAsync(input);
            return await Context.SaveChangesAsync();
        }

        public async Task<int> Update(T input)
        {
            Context.Set<T>().Update(input);
            return await Context.SaveChangesAsync();
        }

        public async Task<ICollection<T>>? GetAll(Expression<Func<T , bool>>? filter = null)
        {
            if (filter == null)
            {
                return await Context.Set<T>().ToListAsync();
            }
            else
            {
                return await Context.Set<T>().Where(filter).ToListAsync();
            }
        }

        public async Task<IQueryable<T>>? GetAllInclude(Expression<Func<T , bool>>? filter = null , params Expression<Func<T , object>>[]? include)
        {
            IQueryable<T> query;
            if (filter != null)
            {
                query = Context.Set<T>().Where(filter);
            }
            query = Context.Set<T>();

            return include.Aggregate(query ,
                (current , includeProperty) => current.Include(includeProperty));
        }

        public async Task<T?> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
    }
}