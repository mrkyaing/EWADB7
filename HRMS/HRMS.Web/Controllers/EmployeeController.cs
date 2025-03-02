using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class EmployeeController : Controller {

        private readonly HRMSWebDbContext _db;
        public EmployeeController(HRMSWebDbContext db) {
            this._db = db;
        }

        public IActionResult List() {
            return View();
        }
        [HttpGet]
        public IActionResult Entry() {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel() {
                DepartmentViewModels = _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList(),
                PositionViewModels = _db.Positions.Where(w => w.IsActive).Select(s => new PositionViewModel {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList()
            };
            return View(employeeViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Entry(EmployeeViewModel employeeViewModel) {
            try {
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
    }
}
