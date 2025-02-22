using System.ComponentModel.DataAnnotations;

namespace HRMS.Web.Models.DataModels {
    public class BaseEntity {
        [Key] //Length char 36
        public required string Id { get; set; }
        public required DateTime CreatedAt { get; set; }
        public required string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public required string Ip { get; set; }
        public required bool IsActive { get; set; }
    }
}
