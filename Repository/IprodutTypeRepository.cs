using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public interface IprodutTypeRepository
    {
        List<ProductType> GetAll();
        void Insert(ProductType productType);
        void Delete(int id);
        void Update(int id, ProductType productType);
        ProductType GetById(int id);

    }
}
