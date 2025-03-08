using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Respostories.Common;

namespace HRMS.Web.Respostories.Domain {
    public class PositionRepository : BaseRepository<PositionEntity>, IPositoryRepository {
        private readonly HRMSWebDbContext _dbContext;
        public PositionRepository(HRMSWebDbContext dbContext) : base(dbContext) {
            this._dbContext = dbContext;
        }
    }
}
