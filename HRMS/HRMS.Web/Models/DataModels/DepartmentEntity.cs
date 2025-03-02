using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Web.Models.DataModels {
    [Table("Department")] //Model Attribute
    public class DepartmentEntity : BaseEntity {
        public required string Code { get; set; }
        public required string Description { get; set; }
        public string? ExtensionPhone { get; set; }
    }
}