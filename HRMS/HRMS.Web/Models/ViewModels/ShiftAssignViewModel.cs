namespace HRMS.Web.Models.ViewModels
{
    public class ShiftAssignViewModel
    {
        public string Id { get; set; }
        public string EmployeeId { get; set; }
        public string ShiftId { get; set; }
        public string DepartmentId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public string EmployeeCode { get; set; }
        public string DepartmentCode { get; set; }
        public string ShiftName { get; set; }

        public IList<EmployeeViewModel> EmployeeViewModels { get; set; }
        public IList<DepartmentViewModel> DepartmentViewModels { get; set; }
        //public IList<ShiftViewModel> ShiftViewModels { get; set; }
    }
}
