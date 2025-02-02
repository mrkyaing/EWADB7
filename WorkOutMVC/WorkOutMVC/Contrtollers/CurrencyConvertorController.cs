using Microsoft.AspNetCore.Mvc;

namespace WorkOutMVC.Contrtollers {
    public class CurrencyConvertorController : Controller {
        [HttpGet]
        public IActionResult ConvetorV1() {
            return View();
        }
        [HttpPost]
        //currencyconvertor/convetorV1
        public IActionResult ConvetorV1(string fromCurrency, decimal inputAmount) {
            var result = 0.0m;
            switch (fromCurrency) {
                case "USD": result = inputAmount * 4000; break;
                case "SDG": result = inputAmount * 3000; break;
                case "THB": result = inputAmount * 130; break;
                case "MYR": result = inputAmount * 200; break;
            }
            ViewBag.CalculatedAmount = result;
            return View();
        }

        [HttpGet]
        public IActionResult ConvetorV2() {
            return View();
        }
        [HttpPost]
        //currencyconvertor/convetorV2
        //binding with Name in HTML attribute
        public IActionResult ConvetorV2(string fromCurrency, decimal inputAmount) {
            var result = 0.0m;
            switch (fromCurrency) {
                case "USD": result = inputAmount * 4000; break;
                case "SDG": result = inputAmount * 3000; break;
                case "THB": result = inputAmount * 130; break;
                case "MYR": result = inputAmount * 200; break;
            }
            ViewBag.SelectedCurrency = fromCurrency;
            ViewBag.InputAmount = inputAmount;
            ViewBag.CalculatedAmount = result;
            return View();
        }
    }
}
