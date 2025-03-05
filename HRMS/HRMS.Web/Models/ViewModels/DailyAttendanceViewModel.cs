namespace HRMS.Web.Models.ViewModels
{
    public class DailyAttendanceViewModel
    {
        public string Id { get; set; }
        public DateTime AttendanceDate { get; set; }
        public TimeSpan InTime { get; set; }
        public TimeSpan OutTime { get; set; }
        public string EmployeeId { get; set; }
        public string DepartmentId { get; set; }
        public string EmployeeCode { get; set; }
        public string DepartmentCode { get; set; }
        public IList<EmployeeViewModel> EmployeeViewModels { get; set; }
        public IList<DepartmentViewModel> DepartmentViewModels { get; set; }
    }
}
