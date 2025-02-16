using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class AccountController : Controller {
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        [HttpPost]//action filter in HTTP Verb
        public IActionResult Login(string userName, string password) {
            if (userName.Equals("admin") && password.Equals("admin")) {
                TempData["Msg"] = $"Hello,{userName}, Nice to see you";
                return RedirectToAction("dashboard");//go to next action url 
            }
            ViewData["Error"] = "user name or password is invalid!";
            return View();
        }
        public IActionResult Dashboard() {
            return View();
        }
        [HttpGet]
        public string TellMeNow() {
            return DateTime.Now.ToString();
        }
        public string FindFriends(string friend) {
            string foundFriend = "no friend";
            string[] myFriends = { "SU SU", "AYE AYE", "MIN MIN" };
            foreach (var f in myFriends) {
                foundFriend = f.Equals(friend.ToUpper()) ? f : foundFriend;
            }
            return foundFriend;
        }
    }
}
