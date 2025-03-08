using HRMS.Web.Models.ViewModels;
using HRMS.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class PositionController : Controller {
        private readonly IPositionService _positionService;

        //Dependency Injection  Service (Postion Service) 

        public PositionController(IPositionService positionService) {
            this._positionService = positionService;
        }

        [HttpGet]
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Entry(PositionViewModel positionVM) {
            try {
                _positionService.Create(positionVM);
                TempData["Msg"] = "Data has been saved successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is created time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }

        public IActionResult List() => View(_positionService.GetAll().ToList());

        //postion/delete?Id=1
        public IActionResult Delete(string Id) {
            try {
                _positionService.Delete(Id);
                TempData["Msg"] = "Data has been deleted successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is deleted time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }
        public IActionResult Edit(string Id) => View(_positionService.GetById(Id));

        [HttpPost]
        public async Task<IActionResult> Update(PositionViewModel positionVM) {
            try {
                _positionService.Update(positionVM);
                TempData["Msg"] = "Data has been updated successfully";
                TempData["IsErrorOccur"] = false;
            }
            catch (Exception e) {
                TempData["Msg"] = "Oh,Sorry error was occured when recrod is deleted time.";
                TempData["IsErrorOccur"] = true;
            }
            return RedirectToAction("List");
        }
    }
}
