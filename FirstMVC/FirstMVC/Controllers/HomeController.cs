using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class HomeController : Controller {

        [HttpGet]
        //Actions method are here
        public IActionResult Index() {
            return View();
        }

        [HttpGet]
        //localhost:7000/home/getproducts
        public string GetProducts() {
            return "This is IPhone 15 from apple proudct.";
        }

        [HttpGet]
        //localhost:7000/home/add
        public int Add() {
            return 1 + 2;
        }
        public ViewResult Friends() {
            return View();
        }
        [NonAction]// 404
        [ActionName("download1")]//this is called action attribute.
        public IActionResult DownoadImage() {
            string fileName = "SE.png";
            string filePath = Path.Combine("wwwroot/files/images/", fileName);
            byte[] fileContent = System.IO.File.ReadAllBytes(filePath);
            return File(fileContent, "image/png", fileName);
        }
    }
}
