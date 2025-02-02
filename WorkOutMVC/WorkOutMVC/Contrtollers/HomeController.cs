using Microsoft.AspNetCore.Mvc;
namespace WorkOutMVC.Contrtollers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
