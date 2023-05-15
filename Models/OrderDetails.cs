using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class OrderDetails
    {
        
        public int Id { get; set; }
        [DisplayName("Product")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [DisplayName("Order")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Products ? Product { get; set; }
        public virtual Order? Order { get; set; }

    }
}
