using EcommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceProject.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        ApllicationDBContext db;
        public ProductsRepository()
        {
            db=new ApllicationDBContext();
        }
        public void Delete(int id)
        {
           db.Products.Remove(GetById(id));
            db.SaveChanges();
        }

        public List<Products> GetAll()
        {
            var result=db.Products.Include(p=>p.ProductTyp).ToList();
            return result;
        }

        public Products GetById(int id)
        {
            Products product=db.Products.Include(p=>p.ProductTyp).FirstOrDefault(p => p.Id == id);
            return product;
        }

        public Products GetByName(string name,string color)
        {
            return db.Products.FirstOrDefault(p =>( p.Name == name.ToLower()&&p.ProductColor==color.ToLower()));
        }

        public void insert(Products product)
        {
            db.Products.Add(product);
            db.SaveChanges();   
        }

        public List<Products> SearchPrice(int? low, int? high)
        {
            var Result = db.Products.Include(p=>p.ProductTyp).Where(p=>(p.Price>=low&&p.Price<=high)).ToList();
            return Result;
        }

        public void Update(int id, Products product)
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }
}
