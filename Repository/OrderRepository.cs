using EcommerceProject.Models;

namespace EcommerceProject.Repository
{
    public class OrderRepository : IOrderRepository
    {
        ApllicationDBContext db;
        public OrderRepository()
        {
            db = new ApllicationDBContext();
        }

        public void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }

        public List<Order> GetAll()
        {
           return db.Orders.ToList();
        }
    }
}
