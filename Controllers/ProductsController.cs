using EcommerceProject.Models;
using EcommerceProject.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace EcommerceProject.Controllers
{
    public class ProductsController : Controller
    {
        IProductsRepository ProductRepo;
        IprodutTypeRepository ProductTypeRepo;
        IHostingEnvironment he;
        public ProductsController( IProductsRepository _ProductRepo,
            IHostingEnvironment _he, IprodutTypeRepository _ProductTypeRepo)
        {
            ProductRepo = _ProductRepo;
            ProductTypeRepo = _ProductTypeRepo;
            he = _he;
        }
        void ViewDataProductType()
        {
            var productType = ProductTypeRepo.GetAll();
            ViewData["ProductType"] = productType;
        }
        public IActionResult Index()
        {
            
            return View(ProductRepo.GetAll());
        }
        public IActionResult New()
        {
            ViewDataProductType();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Products product/*,IFormFile Image*/)
        {
            if(ModelState.IsValid)
            {
                //if(Image!=null)
                //{
                //    var name = Path.Combine(he.WebRootPath+"/images",Path.GetFileName(Image.FileName));
                //    await Image.CopyToAsync(new FileStream(name, FileMode.Create));
                //    product.Image ="images/"+Image.FileName;
                //}
                var SearchProduct = ProductRepo.GetByName(product.Name,product.ProductColor);
                if(SearchProduct!=null)
                {
                    ViewBag.message = "This Product Is Already Exsist" ;
                    ViewDataProductType();
                    return View(product);
                }
                try
                {
                    ViewData["save"] = "Product has been Saved";
                    ProductRepo.insert(product);
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("ProductTypId", "Please Select Product Type");
                }
                
            }
            ViewDataProductType();
            return View(product);
        }
        public IActionResult Edit(int id)
        {
            ViewDataProductType();
            return View(ProductRepo.GetById(id));
        }
        [HttpPost]
        public IActionResult Edit(int id,Products product)
        {
           if(ModelState.IsValid)
            {
                ViewData["edit"] = "Product has been Edited";
                ProductRepo.Update(id,product);
                return RedirectToAction("Index");
            }
            ViewDataProductType();
            return View(product);
        }
        public IActionResult Details(int id)
        {
            ViewDataProductType();
            return View(ProductRepo.GetById(id));
        }
        public IActionResult Delete(int id)
        {
            ViewDataProductType();
            return View(ProductRepo.GetById(id));
        }
        public IActionResult DeleteComfirm(int id)
        {
            ViewData["delete"] = "Product has been deleted";
            ProductRepo.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Index(int? lowAmount,int? heighAmount)
        {
            var products = ProductRepo.SearchPrice(lowAmount, heighAmount);
            if (lowAmount==null|| heighAmount==null)
            {
                products = ProductRepo.GetAll();
            }
            return View(products);
        }
    }
}
