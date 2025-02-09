using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class CalculatorController : Controller {

        //localhost:7000/calculator/getsum?
        [HttpGet]
        public int GetSum(int n1, int n2) {
            return n1 + n2;
        }

        [HttpPost]
        public int PostSum(int n1, int n2) => n1 + n2;
    }
}
