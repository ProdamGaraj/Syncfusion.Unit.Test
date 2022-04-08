using System.Linq;
using Example.DataRepository;
using Microsoft.EntityFrameworkCore;

namespace Example.DataAccess
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, new()
    {

        private CustomerDbContext _dbContext;
        private DbSet<T> _dbSet;

        public EntityRepository(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChanges();
        }

        public virtual IQueryable<T> GetAllQueryable()
        {
            return _dbSet;
        }
    }
}
