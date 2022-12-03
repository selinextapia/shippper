using Microsoft.AspNetCore.Mvc;
using StoreOnline.Service.Contracts;
namespace StoreOnline.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersService orderService;

        public OrderController(IOrdersService orderService)
        {
            this.orderService = orderService;
        }
        public IActionResult Index()
        {
            var categories = this.orderService.GetOrders();
            return View();
        }
    }
}



