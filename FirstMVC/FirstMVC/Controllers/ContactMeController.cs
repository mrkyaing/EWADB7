using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class ContactMeController : Controller {

        [HttpGet]
        public IActionResult Index() {
            int hour = DateTime.Now.Hour;
            //Ternary Operator Style 
            var message = hour < 12 ? " Good Morning" : hour < 15 ? "Good Afternoon" : "Good Evening";
            ViewBag.Msg = SayYourName(name: "MG") + message;
            return View();
        }

        public JsonResult Me() {
            return Json(new { name = "MG", email = "mg@gmail.com", address = "YGN" });
        }
        //? QueryString
        //localhost:7000/contactme/add?n1=1&n2=1&n3=1
        public int Add(int n1, int n2, int n3) {
            return n1 + n2 + n3; // 3
        }
        private string SayYourName(string name) {
            return "Hello," + name;
        }
        //loalhost:7000/contactme/search?q=What is JavaScript?
        public IActionResult Search(string query) {
            string url = "https://www.google.com/search?q=" + query;
            return Redirect(url);
        }
    }
}
