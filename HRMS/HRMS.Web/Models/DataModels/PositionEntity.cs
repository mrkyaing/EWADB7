using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Web.Models.DataModels {
    [Table("Position")] // Model Attribute in here 
    public class PositionEntity : BaseEntity {
        [MaxLength(200)] //Length char 10
        public required string Code { get; set; }
        public required string Description { get; set; }
        public int? Level { get; set; }
    }
}
