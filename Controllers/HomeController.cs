using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Collections.Generic;
using EcommerceProject.Utility;
using System.Text.Json.Serialization;

namespace EcommerceProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IProductsRepository ProductRepo;
        IprodutTypeRepository ProductTypeRepo;

        public HomeController(ILogger<HomeController> logger, IProductsRepository _ProductRepo,
            IprodutTypeRepository _ProductTypeRepo)
        {
            _logger = logger;
            ProductRepo = _ProductRepo;
            ProductTypeRepo = _ProductTypeRepo;
        }

        public IActionResult Index()
        {
            return View(ProductRepo.GetAll());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int productId)
        {
          var result=  ProductRepo.GetById(productId);
            
            return View(result);
        }
        public IActionResult CartItems(int productId)
        {
            List<Products> products = new List<Products>();
            var product=ProductRepo.GetById(productId);
            products = HttpContext.Session.Get<List<Products>>("products");
            if(products==null)
            {
                products = new List<Products>();    
            }
            products.Add(product);
            foreach(var item in products) 
            {
                item.ProductTyp = null;
            }
            HttpContext.Session.Set<List<Products>>("products",products);
            return RedirectToAction("Index");
        }
        //Remove from details view
        public IActionResult RemoveFromCart(int productId)
        {
          List<Products>products=HttpContext.Session.Get<List<Products>>("products");
            if(products!=null)
            {
                Products product = products.FirstOrDefault(p=>p.Id== productId);
                if(product!=null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction("Index");
        }
        //Get product Cart Action Method
        public IActionResult Cart()
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if(products==null)
            {
                products=new List<Products>();
            }
            return View(products);
        }
        //remove from cart
        public IActionResult RemoveCart(int productId)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                Products product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return View("Cart", products);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}