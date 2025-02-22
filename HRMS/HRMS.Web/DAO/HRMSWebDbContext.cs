using HRMS.Web.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Web.DAO {
    public class HRMSWebDbContext : DbContext {
        //constructor interchanging 
        public HRMSWebDbContext(DbContextOptions<HRMSWebDbContext> o) : base(o) {

        }
        //register for all of Data Models as DBSet
        public DbSet<PositionEntity> Positions { get; set; }
    }
}
