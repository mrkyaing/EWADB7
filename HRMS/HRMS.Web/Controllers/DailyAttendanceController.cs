using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers
{
    public class DailyAttendanceController : Controller
    {
        private readonly HRMSWebDbContext _db;

        public DailyAttendanceController(HRMSWebDbContext db)
        {
            this._db = db;
        }
        public IActionResult List()
        {           
            IList<DailyAttendanceViewModel> DailyAttVM = _db.DailyAttendance.Where(w => w.IsActive).Select(s => new DailyAttendanceViewModel
            {
                Id = s.Id,
                AttendanceDate =s.AttendanceDate,
                InTime=s.InTime,
                OutTime=s.OutTime,
                EmployeeCode= _db.Employees.Where(w=>w.IsActive && w.Id == s.EmployeeId).Select(s=>s.Code).FirstOrDefault().ToString() ,
                DepartmentCode= _db.Departments.Where(w => w.IsActive && w.Id == s.DepartmentId).Select(s => s.Code).FirstOrDefault().ToString()
            }).ToList();
            return View(DailyAttVM);
        }

        [HttpGet]
        public IActionResult Entry()
        {
            DailyAttendanceViewModel DailyAttVM = new DailyAttendanceViewModel()
            {
                DepartmentViewModels = _db.Departments.Where(w=>w.IsActive).Select(s=>new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList(),
                EmployeeViewModels = _db.Employees.Where(w=>w.IsActive).Select(s=>new EmployeeViewModel
                {
                    Id=s.Id,
                    Code=s.Code,
                    Name=s.Name
                }).ToList()
            };

            return View(DailyAttVM);
        }
        [HttpPost]
        public async Task<IActionResult> Entry(DailyAttendanceViewModel DailyAttendVM)
        {
            try
            {
                DailyAttendanceEntity DailyAttEntity = new DailyAttendanceEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    AttendanceDate = DailyAttendVM.AttendanceDate,
                    InTime = DailyAttendVM.InTime,
                    OutTime = DailyAttendVM.OutTime,
                    DepartmentId = DailyAttendVM.DepartmentId,
                    EmployeeId = DailyAttendVM.EmployeeId,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };
                _db.DailyAttendance.Add(DailyAttEntity);
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
                DailyAttendanceEntity DailyAttEntity = _db.DailyAttendance.Where(w => w.IsActive && w.Id == id).FirstOrDefault();
                if (DailyAttEntity is not null)
                {
                    DailyAttEntity.IsActive = false;
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
            DailyAttendanceViewModel DailyAttVM = _db.DailyAttendance.Where(w => w.IsActive && w.Id == id).Select(s => new DailyAttendanceViewModel
            {
                Id = s.Id,
                AttendanceDate = s.AttendanceDate,
                InTime = s.InTime,
                OutTime = s.OutTime,
                EmployeeId = s.EmployeeId,
                DepartmentId = s.DepartmentId,

                DepartmentViewModels = _db.Departments.Where(w => w.IsActive).Select(s => new DepartmentViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Description = s.Description
                }).ToList(),

                EmployeeViewModels = _db.Employees.Where(w => w.IsActive).Select(s => new EmployeeViewModel
                {
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name
                }).ToList()

            }).FirstOrDefault();

            return View(DailyAttVM);
        }

        public async Task<IActionResult> update(DailyAttendanceViewModel DailyAttVM)
        {
            try
            {
                DailyAttendanceEntity DailyAttEntity = _db.DailyAttendance.Where(w => w.IsActive && w.Id == DailyAttVM.Id).FirstOrDefault();
                if (DailyAttEntity is not null)
                {
                    DailyAttEntity.AttendanceDate = DailyAttVM.AttendanceDate;
                    DailyAttEntity.InTime = DailyAttVM.InTime;
                    DailyAttEntity.OutTime = DailyAttVM.OutTime;
                    DailyAttEntity.EmployeeId = DailyAttVM.EmployeeId;
                    DailyAttEntity.DepartmentId = DailyAttVM.DepartmentId;
                    DailyAttEntity.UpdatedAt = DateTime.Now;
                    DailyAttEntity.UpdatedBy = "system";
                    DailyAttEntity.Ip = await NetworkHelper.GetIpAddressAsnyc();

                    _db.DailyAttendance.Update(DailyAttEntity);
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
