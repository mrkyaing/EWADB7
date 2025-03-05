using HRMS.Web.DAO;
using HRMS.Web.Models.DataModels;
using HRMS.Web.Models.ViewModels;
using HRMS.Web.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class PositionController : Controller {

        //Dependency Injection  dbContext 
        private readonly HRMSWebDbContext _db;
        public PositionController(HRMSWebDbContext db) {
            _db = db;
        }

        [HttpGet]
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Entry(PositionViewModel positionVM) {
            try {
                //DTO >> Data Transfer Object in hre ( from View Models to Data Model)
                PositionEntity positionEntity = new PositionEntity() {
                    Id = Guid.NewGuid().ToString(),//for Primary Key 
                    Code = positionVM.Code,
                    Description = positionVM.Description,
                    Level = positionVM.Level,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = await NetworkHelper.GetIpAddressAsnyc()
                };
                _db.Positions.Add(positionEntity);//adding the recrod to the context 
                _db.SaveChanges();//saving the data to the database in here .
                TempData["Msg"] = "Data has been saved successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is created time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }

        public IActionResult List() {
            IList<PositionViewModel> positionViews = _db.Positions.Where(w => w.IsActive).Select(s => new PositionViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Level = s.Level.Value
            }).ToList();
            return View(positionViews);
        }
        //postion/delete?Id=1
        public IActionResult Delete(string Id) {
            try {
                PositionEntity positionEntity = _db.Positions.Where(w => w.Id == Id).FirstOrDefault();
                if (positionEntity is not null) {
                    positionEntity.IsActive = false;
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
            PositionViewModel positionView = _db.Positions.Where(w => w.IsActive && w.Id == Id).Select(s => new PositionViewModel {
                Id = s.Id,
                Code = s.Code,
                Description = s.Description,
                Level = s.Level.Value
            }).FirstOrDefault();
            return View(positionView);
        }
        [HttpPost]
        public async Task<IActionResult> Update(PositionViewModel positionVM) {
            try {
                //DTO >> Data Transfer Object in hre ( from View Models to Data Model)
                PositionEntity existingPositionEntity = _db.Positions.Where(w => w.IsActive && w.Id == positionVM.Id).FirstOrDefault();
                if (existingPositionEntity is not null) {
                    existingPositionEntity.Description = positionVM.Description;
                    existingPositionEntity.Level = positionVM.Level;
                    existingPositionEntity.UpdatedAt = DateTime.Now;
                    existingPositionEntity.UpdatedBy = "system";
                    existingPositionEntity.Ip = await NetworkHelper.GetIpAddressAsnyc();
                }
                _db.Positions.Update(existingPositionEntity);//updating the recrod to the context
                _db.SaveChanges();//saving the data to the database in here .
                TempData["Msg"] = "Data has been updated successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is deleted time.";
                TempData["IsErrorOccur"] = true;
            }

            return RedirectToAction("List");
        }
    }
}
