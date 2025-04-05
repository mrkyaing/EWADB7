using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Services;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class EmployeeController : Controller {

        private readonly HRMSWebDbContext _db;
        private readonly IUserService _userService;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(HRMSWebDbContext db, IUserService userService, IEmployeeService employeeService) {
            this._db = db;
            this._userService = userService;
            this._employeeService = employeeService;
        }

        public IActionResult List() {
            IList<EmployeeViewModel> employees = (from e in _db.Employees
                                                  join p in _db.Positions
                                                  on e.PositionId equals p.Id
                                                  join d in _db.Departments
                                                  on e.DepartmentId equals d.Id
                                                  where e.IsActive && d.IsActive && p.IsActive
                                                  select new EmployeeViewModel {
                                                      Id = e.Id,
                                                      Code = e.Code,
                                                      Name = e.Name,
                                                      DOB = e.DOB,
                                                      DOR = e.DOR.Value,
                                                      DOE = e.DOE,
                                                      Address = e.Address,
                                                      Phone = e.Phone,
                                                      DepartmentInfo = d.Code + "/" + d.Description,
                                                      PositionInfo = p.Code + "/" + p.Description
                                                  }).ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Entry() {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel {
                DepartmentViewModels = GetAllDepartments(),
                PositionViewModels = GetAllPositions()
            };
            return View(employeeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Entry(EmployeeViewModel employeeViewModel) {
            try {
                string userId = await _userService.CreateUserWithRole(employeeViewModel.Email, employeeViewModel.Email);
                if (userId.Equals("unknown")) {
                    TempData["Msg"] = "We face the error when pre-create the user recrod.";
                    TempData["IsErrorOccur"] = true;
                    return View();
                }
                //DTO Processs from View Model to Data Model for save process
                EmployeeEntity employeeEntity = new EmployeeEntity() {
                    Id = Guid.NewGuid().ToString(),
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    DOB = employeeViewModel.DOB,
                    DOE = employeeViewModel.DOE,
                    DOR = employeeViewModel.DOR,
                    Address = employeeViewModel.Address,
                    BasicSalary = employeeViewModel.BasicSalary,
                    Phone = employeeViewModel.Phone,
                    Gender = employeeViewModel.Gender,
                    DepartmentId = employeeViewModel.DepartmentId,
                    PositionId = employeeViewModel.PositionId,
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    UserId = userId,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };
                _db.Employees.Add(employeeEntity);
                _db.SaveChanges();
                TempData["Msg"] = "Data has been saved successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is created time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }
        public IActionResult Delete(string Id) {
            try {
                var employeeEntity = _db.Employees.Where(w => w.Id == Id).FirstOrDefault();
                if (employeeEntity is not null) {
                    employeeEntity.IsActive = false;
                    _db.Update(employeeEntity);
                    _db.SaveChanges();
                    TempData["Msg"] = "Data has been deleted successfully";
                    TempData["IsErrorOccur"] = false;
                }
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is deleted time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(string Id) {
            EmployeeViewModel employeeView = _db.Employees.Where(w => w.IsActive && w.Id == Id).Select(e => new EmployeeViewModel {
                Id = e.Id,
                Code = e.Code,
                Name = e.Name,
                DOB = e.DOB,
                DOR = e.DOR.Value,
                DOE = e.DOE,
                Address = e.Address,
                Phone = e.Phone,
                PositionId = e.PositionId,
                DepartmentId = e.DepartmentId
            }).FirstOrDefault();
            employeeView.PositionViewModels = GetAllPositions();
            employeeView.DepartmentViewModels = GetAllDepartments();
            return View(employeeView);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeViewModel employeeViewModel) {
            try {
                //DTO Processs from View Model to Data Model for save process
                EmployeeEntity employeeEntity = _db.Employees.Where(w => w.IsActive && w.Id == employeeViewModel.Id).FirstOrDefault();
                employeeEntity.Code = employeeViewModel.Code;
                employeeEntity.Name = employeeViewModel.Name;
                employeeEntity.Email = employeeViewModel.Email;
                employeeEntity.DOB = employeeViewModel.DOB;
                employeeEntity.DOE = employeeViewModel.DOE;
                employeeEntity.DOR = employeeViewModel.DOR;
                employeeEntity.Address = employeeViewModel.Address;
                employeeEntity.BasicSalary = employeeViewModel.BasicSalary;
                employeeEntity.Phone = employeeViewModel.Phone;
                employeeEntity.Gender = employeeViewModel.Gender;
                employeeEntity.DepartmentId = employeeViewModel.DepartmentId;
                employeeEntity.PositionId = employeeViewModel.PositionId;
                employeeEntity.Ip = await NetworkHelper.GetIpAddressAsnyc();
                employeeEntity.UpdatedBy = "system";
                employeeEntity.UpdatedAt = DateTime.Now;
                _db.Employees.Update(employeeEntity);
                _db.SaveChanges();
                TempData["Msg"] = "Data has been updated successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is updated time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }

        public IActionResult EmployeeDetailReport() => View();

        [HttpPost]
        public IActionResult EmployeeDetailReport(string fromCode, string toCode) {
            string fileName = $"EmployeeDetail-{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}.xlsx";
            string fileContextType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            List<EmployeeDetailReportViewModel> reportData = _employeeService.GetByCode(fromCode, toCode).ToList();
            if (reportData.Count > 0) {
                var fileOutput = ReportHelper.ExportToExcel(reportData, fileName);
                ViewBag.Msg = "Employee detail report is successfully exported.";
                return File(fileOutput, fileContextType, fileName);
            }
            else {
                ViewBag.Msg = "There is no data to export employee detail report.";
            }
            return View();
        }
        private IList<DepartmentViewModel> GetAllDepartments() {
            return _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description
            }).ToList();
        }
        private IList<PositionViewModel> GetAllPositions() {
            return _db.Positions.Where(w => w.IsActive).Select(s => new PositionViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description
            }).ToList();
        }

    }
}
