using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class EmployeeController : Controller {

        private readonly ILogger<EmployeeController> _logger;
        //Depedency Injection (Constructor)
        public EmployeeController(ILogger<EmployeeController> logger) {
            _logger = logger;
        }
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(EmployeeModel employeeModel) {
            _logger.LogInformation("Id" + employeeModel.Id);
            _logger.LogInformation("First Name" + employeeModel.FirstName);
            _logger.LogInformation("City " + employeeModel.HomeAddress.City);
            _logger.LogInformation("Township " + employeeModel.HomeAddress.Township);
            _logger.LogInformation("Zip Code " + employeeModel.HomeAddress.ZipCode);
            return View();
        }

        public IActionResult EntryAsList() {
            return View();
        }
        [HttpPost]
        public IActionResult EntryAsList(IList<EmployeeModel> employeeModels) {
            _logger.LogInformation("Total Employee Count" + employeeModels.Count);
            return View();
        }

    }
}
