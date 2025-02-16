using FirstMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVC.Controllers {
    public class OrderController : Controller {
        public IActionResult MakeOrder() {
            return View();
        }

        [HttpPost]
        public IActionResult MakeOrder(OrderModel order) {
            decimal TotalPrice = order.UnitPrice * order.Quantity;
            return Json(TotalPrice);
        }

    }
}
