using HRMS.Web.DAO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRMS.Web.Respostories.Common {
    public class BaseRepository<T> : IBaseRepository<T> where T : class {
        private readonly HRMSWebDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(HRMSWebDbContext dbContext) {
            this._dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public void Create(T entity) {
            _dbContext.Add<T>(entity);
        }

        public void Delete(T entity) {
            _dbContext.Update<T>(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> expression) {
            return _dbSet.AsNoTracking().Where(expression).AsEnumerable();
        }

        public void Update(T entity) {
            _dbContext.Update<T>(entity);
        }
    }
}
