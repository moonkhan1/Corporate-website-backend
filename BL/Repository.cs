using DAL;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace BL
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private DataBaseContext _context;
        private DbSet<T> _dbSet;

        public Repository()
        {
            if(_context == null)
            {
                _context = new DataBaseContext();
                _dbSet = _context.Set<T>();
            }
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            return query;
        }

        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAll();
            BindIncludeProperties(query, includeProperties);
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query;
        }

        public async Task<List<T>> GetAllListAsync()
        {
            return await GetAll().ToListAsync();
        }

        public Task<List<T>> GetAllList(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).ToListAsync();
        }

        public Task<List<T>> GetAllListIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAll();
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.ToListAsync();
        }

        public ValueTask<T> Find(int? id)
        {
            return _dbSet.FindAsync(id);
        }

        public Task<T> GetFirst(Expression<Func<T, bool>> predicate)
        {
            return GetAll().FirstOrDefaultAsync(predicate);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return GetAll().Where(predicate);
        }

        public IQueryable<T> FindByIncluding(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = GetAll();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return query.Where(predicate);
        }

        public Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }

        public Task<bool> All(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.AllAsync(predicate);
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.CountAsync(predicate);
        }

        public async Task<int> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return _context.SaveChanges();
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> entities = _dbSet.Where(predicate);

            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

        private static void BindIncludeProperties(IQueryable<T> query, IEnumerable<Expression<Func<T, object>>> includeProperties)
        {
            includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task Commit(CancellationToken cancellationToken = new CancellationToken())
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public List<T> GetAllList()
        {
            return _dbSet.ToList();
        }

        public IQueryable<T> GetAllListQueryable()
        {
            return _dbSet.AsQueryable();
        }


        //public int Add(T entity)
        //{
        //    _dbSet.Add(entity);
        //    return _context.SaveChanges();
        //}

        //public T Find(int id)
        //{
        //    return _dbSet.Find(id);
        //}

        //public T Get()
        //{
        //    throw new NotImplementedException();
        //}

        //public T Get(Expression<Func<T, bool>> expression)
        //{
        //    return _dbSet.FirstOrDefault(expression);
        //}

        //public List<T> GetAll()
        //{
        //    return _dbSet.ToList();
        //}

        //public List<T> GetAll(Expression<Func<T, bool>> expression)
        //{
        //    return _dbSet.Where(expression).ToList();
        //}

        //public Task<IEnumerable<T>> GetAllByAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> GetByAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public int Remove(T entity)
        //{
        //    _dbSet.Remove(entity);
        //    return _context.SaveChanges();
        //}

        //public int Update(T entity)
        //{
        //    _dbSet.Update(entity);
        //    return _context.SaveChanges(); 
        //}
    }
}
