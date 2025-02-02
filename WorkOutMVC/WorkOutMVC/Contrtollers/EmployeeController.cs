using Microsoft.AspNetCore.Mvc;
using WorkOutMVC.Models;

namespace WorkOutMVC.Contrtollers {
    public class EmployeeController : Controller {

        private readonly ILogger<EmployeeController> _logger;
        //Constructor Injection in here 
        public EmployeeController(ILogger<EmployeeController> logger) {
            _logger = logger;
        }
        public IActionResult Entry() {
            return View();
        }
        [HttpPost]
        public IActionResult Entry(EmployeeModel employeeModel) {
            _logger.LogInformation("Employee Entry");
            _logger.LogInformation(" Id: " + employeeModel.Id);
            _logger.LogInformation(" FullName: " + employeeModel.FirstName + " " + employeeModel.LastName);
            _logger.LogInformation(" City: " + employeeModel.HomeAddress.City);
            _logger.LogInformation(" Street: " + employeeModel.HomeAddress.Street);
            _logger.LogInformation(" ZipCode: " + employeeModel.HomeAddress.ZipCode);
            return View();
        }
    }
}
