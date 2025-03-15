using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Respostories.Common;

namespace HRMS.Web.Respostories.Domain {
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository {
        private readonly HRMSWebDbContext _context;
        public EmployeeRepository(HRMSWebDbContext dbContext) : base(dbContext) {
            _context = dbContext;
        }
    }
}
