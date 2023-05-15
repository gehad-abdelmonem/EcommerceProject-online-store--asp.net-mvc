using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public interface IProductsRepository
    {
        List<Products> GetAll();
        void insert(Products product);
        Products GetById(int id);
        Products GetByName(string name,string color);
        void Delete(int id);
        void Update(int id,Products product);
        List<Products> SearchPrice(int? low ,int? high);

    }
}
