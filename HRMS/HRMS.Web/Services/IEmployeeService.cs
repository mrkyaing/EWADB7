using HRMS.Web.Models.ViewModels;

namespace HRMS.Web.Services {
    public interface IEmployeeService {
        IEnumerable<EmployeeDetailReportViewModel> GetByCode(string fromCode, string toCode);
        IEnumerable<EmployeeDetailReportViewModel> GetByDepartmentId(string departmentId);
    }
}
