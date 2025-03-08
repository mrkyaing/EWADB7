using System.Linq.Expressions;

namespace HRMS.Web.Respostories.Common {
    public interface IBaseRepository<T> where T : class {
        //crud process in here .
        //create 
        void Create(T entity);
        //R
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        //u
        void Update(T entity);
        //D
        void Delete(T entity);
    }
}
