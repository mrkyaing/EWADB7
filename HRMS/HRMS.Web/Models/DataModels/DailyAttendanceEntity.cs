using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Web.Models.DataModels
{
    [Table("DailyAttendance")]
    public class DailyAttendanceEntity:BaseEntity
    {
        public required DateTime AttendanceDate { get; set; }
        public required TimeSpan InTime { get; set; }
        public  required TimeSpan OutTime { get; set; }
        public  required string EmployeeId { get; set; }
        public  required string DepartmentId { get; set; }
    }
}
