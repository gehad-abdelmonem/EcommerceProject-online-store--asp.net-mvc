using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void Add(Order order);
    }
}
