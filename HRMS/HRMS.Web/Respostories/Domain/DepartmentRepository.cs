using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Respostories.Common;

namespace HRMS.Web.Respostories.Domain {
    public class DepartmentRepository : BaseRepository<DepartmentEntity>, IDepartmentRepository {
        private readonly HRMSWebDbContext _dbContext;

        public DepartmentRepository(HRMSWebDbContext dbContext) : base(dbContext) {
            this._dbContext = dbContext;
        }
    }
}
