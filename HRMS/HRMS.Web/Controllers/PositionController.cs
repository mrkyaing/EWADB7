using HRMS.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Web.Controllers {
    public class PositionController : Controller {
        [HttpGet]
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(PositionViewModel positionVM) {
            return View();
        }

    }
}
