using HRMS.Web.Models.ViewModels;
using HRMS.Web.UnitOfWorks;

namespace HRMS.Web.Services {
    public class EmployeeService : IEmployeeService {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork) {
            this._unitOfWork = unitOfWork;
        }
        public IEnumerable<EmployeeDetailReportViewModel> GetByCode(string fromCode, string toCode) {
            IEnumerable<EmployeeDetailReportViewModel> employeeDetails = (from e in _unitOfWork.EmployeeRepository.GetAll(w => w.IsActive)
                                                                          join p in _unitOfWork.PositoryRepository.GetAll(w => w.IsActive)
                                                                          on e.PositionId equals p.Id
                                                                          join d in _unitOfWork.DepartmentRepository.GetAll(w => w.IsActive)
                                                                          on e.DepartmentId equals d.Id
                                                                          select new EmployeeDetailReportViewModel {
                                                                              Code = e.Code,
                                                                              Name = e.Name,
                                                                              DOB = e.DOB,
                                                                              DOR = e.DOR.Value,
                                                                              DOE = e.DOE,
                                                                              Address = e.Address,
                                                                              Phone = e.Phone,
                                                                              DepartmentInfo = d.Code + "/" + d.Description,
                                                                              PositionInfo = p.Code + "/" + p.Description
                                                                          });
            return employeeDetails;
        }

        public IEnumerable<EmployeeDetailReportViewModel> GetByDepartmentId(string departmentId) {
            throw new NotImplementedException();
        }
    }
}
