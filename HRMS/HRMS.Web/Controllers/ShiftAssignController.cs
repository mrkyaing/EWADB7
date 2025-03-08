using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class ShiftAssignController : Controller
    {
        private readonly HRMSWebDbContext _db;

        public ShiftAssignController(HRMSWebDbContext db)
        {
            this._db = db;
        }
        public IActionResult List()
        {
            IList<ShiftAssignViewModel> ShiftAssignVM = _db.ShiftAssigns.Where(w => w.IsActive).Select(s => new ShiftAssignViewModel
            {
                Id = s.Id,
                EmployeeCode = _db.Employees.Where(w => w.IsActive && w.Id == s.EmployeeId).Select(s => s.Code).FirstOrDefault().ToString(),
                //ShiftName = _db.Shifts.Where(w => w.IsActive && w.Id == s.ShiftId).Select(s => s.Name).FirstOrDefault().ToString(),
                ShiftName = s.ShiftId,
                DepartmentCode = _db.Departments.Where(w => w.IsActive && w.Id == s.DepartmentId).Select(s => s.Code).FirstOrDefault().ToString(),
                FromDate = s.FromDate,
                ToDate = s.ToDate
            }).ToList();
            return View(ShiftAssignVM);
        }

        [HttpGet]
        public IActionResult Entry()
        {
            ShiftAssignViewModel ShiftAssVM = new ShiftAssignViewModel()
            {
                DepartmentViewModels = _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList(),
                //ShiftViewModels = _db.Shifts.Where(w => w.IsActive).Select(s => new ShiftViewModel
                //{
                //    Id = s.Id,
                //    Name = s.Name
                //}).ToList(),
                EmployeeViewModels = _db.Employees.Where(w => w.IsActive).Select(s => new EmployeeViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name
                }).ToList()
            };

            return View(ShiftAssVM);
        }

        [HttpPost]
        public async Task<IActionResult> Entry(ShiftAssignViewModel ShiftAssignVM)
        {
            try
            {
                ShiftAssignEntity shiftAssignEntity = new ShiftAssignEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    EmployeeId = ShiftAssignVM.EmployeeId,
                    ShiftId = ShiftAssignVM.ShiftId,
                    DepartmentId = ShiftAssignVM.DepartmentId,
                    FromDate = ShiftAssignVM.FromDate,
                    ToDate = ShiftAssignVM.ToDate,

                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };
                _db.ShiftAssigns.Add(shiftAssignEntity);
                _db.SaveChanges();

                TempData["Msg"] = "Data has been saved successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is created time.";
                TempData["IsErrorOccur"] = true;
            }

            return RedirectToAction("List");
        }
        public IActionResult Delete(string id)
        {
            try
            {
                ShiftAssignEntity ShiftAssignEntity = _db.ShiftAssigns.Where(w => w.IsActive && w.Id == id).FirstOrDefault();
                if (ShiftAssignEntity is not null)
                {
                    ShiftAssignEntity.IsActive = false;
                    _db.SaveChanges();

                    TempData["Msg"] = "Data has been deleted successfully";
                    TempData["IsErrorOccur"] = false;
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is deleted time.";
                TempData["IsErrorOccur"] = true;
            }

            return RedirectToAction("List");
        }
        public IActionResult Edit(string id)
        {
            ShiftAssignViewModel shiftAssignVM = _db.ShiftAssigns.Where(w => w.IsActive && w.Id == id).Select(s => new ShiftAssignViewModel
            {
                Id = s.Id,
                EmployeeId = s.EmployeeId,
                ShiftId = s.ShiftId,
                DepartmentId = s.DepartmentId,
                FromDate = s.FromDate,
                ToDate = s.ToDate,
                DepartmentViewModels = _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList(),

                //ShiftViewModels = _db.Shifts.Where(w => w.IsActive).Select(s => new ShiftViewModel
                //{
                //    Id = s.Id,
                //    Name = s.Name
                //}).ToList(),

                EmployeeViewModels = _db.Employees.Where(w => w.IsActive).Select(s => new EmployeeViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name
                }).ToList()

            }).FirstOrDefault();

            return View(shiftAssignVM);
        }

        public async Task<IActionResult> update(ShiftAssignViewModel shiftAssignVM)
        {
            try
            {
                ShiftAssignEntity shiftAssignEntity = _db.ShiftAssigns.Where(w => w.IsActive && w.Id == shiftAssignVM.Id).FirstOrDefault();
                if (shiftAssignEntity is not null)
                {
                    shiftAssignEntity.EmployeeId = shiftAssignVM.EmployeeId;
                    shiftAssignEntity.ShiftId = shiftAssignVM.ShiftId;
                    shiftAssignEntity.DepartmentId = shiftAssignVM.DepartmentId;
                    shiftAssignEntity.UpdatedAt = DateTime.Now;
                    shiftAssignEntity.UpdatedBy = "system";
                    shiftAssignEntity.Ip = await NetworkHelper.GetIpAddressAsnyc();

                    _db.ShiftAssigns.Update(shiftAssignEntity);
                    _db.SaveChanges();

                    TempData["Msg"] = "Data has been updated successfully";
                    TempData["IsErrorOccur"] = false;
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is updated time.";
                TempData["IsErrorOccur"] = true;
            }

            return RedirectToAction("List");
        }
    }
}
