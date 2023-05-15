using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public class ProductTypeRepository : IprodutTypeRepository
    {
        ApllicationDBContext db;
        public ProductTypeRepository()
        {
            db= new ApllicationDBContext();
        }
        public List<ProductType> GetAll()
        {
           var result= db.ProductTypes.ToList();
            return result;
        }
        public void Delete(int id)
        {
            ProductType productType=db.ProductTypes.FirstOrDefault(x => x.Id==id);
            db.ProductTypes.Remove(productType);
            db.SaveChanges();
        }

        public void Insert(ProductType productType)
        {
            db.ProductTypes.Add(productType);
            db.SaveChanges();
        }

        public void Update(int id,ProductType productType)
        {
            db.ProductTypes.Update(productType);    
            db.SaveChanges();
        }
        public ProductType GetById(int id)
        {
           ProductType productType= db.ProductTypes.FirstOrDefault(p=>p.Id==id);
            return productType;
        }
    }
}
