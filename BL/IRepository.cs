using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    interface IRepository<T> : IDisposable where T : IEntity
    {
        //List<T> GetAll();
        //List<T> GetAll(Expression<Func<T, bool>> expression);
        //T Get();
        //T Get(Expression<Func<T, bool>> expression);
        //Task<T> GetByAsync();
        //Task<IEnumerable<T>> GetAllByAsync();
        //T Find(int id);
        //int Add(T entity);
        //int Update(T entity);
        //int Remove(T entity);

        IQueryable<T> GetAll();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllList();
        Task<List<T>> GetAllListIncluding(params Expression<Func<T, object>>[] includeProperties);
        ValueTask<T> Find(int id);
        Task<T> GetFirst(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);

        Task<bool> All(Expression<Func<T, bool>> predicate);

        Task<int> Count();

        Task<int> Count(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteWhere(Expression<Func<T, bool>> predicate);

        Task Commit(CancellationToken cancellationToken = default);


    }
}
