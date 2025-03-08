using HRMS.Web.Respostories.Domain;

namespace HRMS.Web.UnitOfWorks {
    public interface IUnitOfWork {
        void Commit();
        void Rollback();

        IPositoryRepository PositoryRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
    }
}
