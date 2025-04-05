namespace HRMS.Web.Models.ViewModels {
    public class EmployeeDetailReportViewModel {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DOB { get; set; }
        public string DOE { get; set; }
        public string DOR { get; set; }
        public string Address { get; set; }
        public decimal BasicSalary { get; set; }
        public string Phone { get; set; }
        public string DepartmentInfo { get; set; } // to list for showing 
        public string PositionInfo { get; set; }// to list for showing 
    }
}
