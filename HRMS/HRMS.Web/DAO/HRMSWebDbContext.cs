using HRMS.Web.Models.DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Web.DAO {
    public class HRMSWebDbContext : IdentityDbContext<IdentityUser, IdentityRole, string> {
        //constructor interchanging 
        public HRMSWebDbContext(DbContextOptions<HRMSWebDbContext> o) : base(o) {
        }
        //register for all of Data Models as DBSet
        public DbSet<PositionEntity> Positions { get; set; }
        public DbSet<DepartmentEntity> Departments { get; set; }
        public DbSet<EmployeeEntity> Employees { get; set; }
        public DbSet<DailyAttendanceEntity> DailyAttendance { get; set; }
        public DbSet<ShiftAssignEntity> ShiftAssigns { get; set; }
    }
}
