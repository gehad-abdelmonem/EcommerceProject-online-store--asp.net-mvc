using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceProject.Controllers
{
    public class ProductTypeController: Controller
    {
        IprodutTypeRepository ProductTypeRepo;
        public ProductTypeController(IprodutTypeRepository _ProductTypeRepo)//inject
        {
            ProductTypeRepo= _ProductTypeRepo;

        }
       public IActionResult Index()
        {
            
            return View(ProductTypeRepo.GetAll());
            
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(ProductType productType)
        {
            if(ModelState.IsValid) 
            {
                TempData["Save"] = "Product Type has been Saved  ";
                ProductTypeRepo.Insert(productType);
                return RedirectToAction("Index");
            }
            return View(productType);
        }
        
        public IActionResult Delete(int id)
        {
            
            return View(ProductTypeRepo.GetById(id));
        }
        public IActionResult FinalDelete(int id)
        {
           ProductTypeRepo.Delete(id);
           return RedirectToAction("Index");  
        }
        public IActionResult Edit(int id)
        {
            
            return View(ProductTypeRepo.GetById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,ProductType productType)
        {
            if(ModelState.IsValid)
            {
                TempData["edit"] = "Product Type has been Edited";
                ProductTypeRepo.Update(id,productType);
                return RedirectToAction("Index");
            }
            return View(productType);
        }
    }
}
