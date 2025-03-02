using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class DepartmentController : Controller {
        //Dependedncy Injection dbContext;
        private readonly HRMSWebDbContext _db;

        public DepartmentController(HRMSWebDbContext db) {
            _db = db;
        }

        [HttpGet]
        public IActionResult Entry() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entry(DepartmentViewModel departmentVM) {

            try {
                DepartmentEntity deptEntity = new DepartmentEntity() {
                    Id = Guid.NewGuid().ToString(),
                    Code = departmentVM.Code,
                    Description = departmentVM.Description,
                    ExtensionPhone = departmentVM.ExtensionPhone,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };

                _db.Departments.Add(deptEntity);
                _db.SaveChanges();

                TempData["Msg"] = "Data has been saved successfully.";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception) {
                TempData["Msg"] = "Oh, sorry error was occured when record is created time.";
                TempData["IsErrorOccur"] = true;
            }

            return RedirectToAction("List");
        }

        public IActionResult List() {
            IList<DepartmentViewModel> deptVM = _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel {
                Code = s.Code,
                Description = s.Description,
                ExtensionPhone = s.ExtensionPhone
            }).ToList();


            return View(deptVM);
        }
    }
}