using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Web.Models.DataModels {
    [Table("Employee")] //Model Attribute
    public class EmployeeEntity : BaseEntity {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Gender { get; set; }
        public required DateTime DOB { get; set; }
        public required DateTime DOE { get; set; }
        public DateTime? DOR { get; set; }
        public string? Address { get; set; }
        public required decimal BasicSalary { get; set; }
        public required string Phone { get; set; }
        public required string DepartmentId { get; set; }
        public required string PositionId { get; set; }
        public required string UserId { get; set; }
    }
}
