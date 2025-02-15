using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class CurrencyConvertorController : Controller {
        [HttpGet]
        public IActionResult CurrencyConvertorV1() {
            return View();
        }

        [HttpPost]
        public IActionResult CurrencyConvertorV1(string selectedCurrency, decimal inputAmount) {
            decimal calculatedAmount = 0;
            switch (selectedCurrency) {
                case "usd": calculatedAmount = inputAmount * 4000; break;
                case "sgd": calculatedAmount = inputAmount * 3000; break;
                case "eur": calculatedAmount = inputAmount * 4500; break;
            }
            ViewData["result"] = calculatedAmount;
            return View();
        }

        [HttpGet]
        public IActionResult CurrencyConvertorV2() {
            ViewBag.SelectedCurrency = "x";
            return View();
        }

        [HttpPost]
        public IActionResult CurrencyConvertorV2(string selectedCurrency, decimal inputAmount) {
            decimal calculatedAmount = 0;

            if (selectedCurrency.Equals("x")) {
                ViewData["Error"] = "select one currency";
                ViewBag.SelectedCurrency = "x";
                return View();
            }

            ViewBag.SelectedCurrency = selectedCurrency;
            ViewBag.InputedAmount = inputAmount;
            switch (selectedCurrency) {
                case "usd": calculatedAmount = inputAmount * 4000; break;
                case "sgd": calculatedAmount = inputAmount * 3000; break;
                case "eur": calculatedAmount = inputAmount * 4500; break;
            }
            ViewData["result"] = calculatedAmount;
            return View();
        }
    }
}
