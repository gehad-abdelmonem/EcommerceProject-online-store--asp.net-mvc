using EcommerceProject.Models;
using EcommerceProject.Repository;
using EcommerceProject.Utility;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository orderRepo;
        public OrderController(IOrderRepository _orderRepo)
        {
            orderRepo= _orderRepo;
            
        }
        //Get Checkout action method
        public void governorate()
        {
            List<string> governorates = new List<string>
            { "Monufia","Cairo", "Alexandria", "Gizeh", "Qalyubia", "Port Said","Suez","Luxor","Dakahlia",
            "Gharbia","Asyut","Ismailia","Faiyum","Sharqia","Beheira","Beni Suef","Red Sea","Sharqia","Kafr el-Sheikh"
            };
            
            ViewBag.governorates= governorates;
        }
        public IActionResult CheckOut()
        {
            governorate();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckOut(Order newOrder)
        {
            
                List<Products> products = HttpContext.Session.Get<List<Products>>("products");
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        OrderDetails orderDetails = new OrderDetails();
                        orderDetails.ProductId = product.Id;
                        orderDetails.OrderId = newOrder.Id;
                        newOrder.OrderDetails.Add(orderDetails);
                    }
                }
                newOrder.OrderNo = GetOrder();
                orderRepo.Add(newOrder);     
                HttpContext.Session.Set("products", new List<Products>());
                return RedirectToAction("Index", "Home");
            
        }
        public string GetOrder()
        {
            int RowCount = orderRepo.GetAll().Count()+1;
            return RowCount.ToString("000");
        }

    }
}
