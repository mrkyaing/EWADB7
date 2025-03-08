using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Web.Models.DataModels
{
    [Table("ShiftAssign")]
    public class ShiftAssignEntity : BaseEntity
    {
        public required string EmployeeId { get; set; }
        public required string ShiftId { get; set; }
        public required string DepartmentId { get; set; }
        public required DateTime FromDate { get; set; }
        public required DateTime ToDate { get; set; }
    }
}
