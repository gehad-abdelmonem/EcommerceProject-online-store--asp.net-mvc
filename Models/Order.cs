using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EcommerceProject.Models
{
    public class Order
    {
        public Order()
        {
           OrderDetails = new List<OrderDetails>();
        }
        public int Id { get; set; }
        [DisplayName("Order No")]
        public string OrderNo { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Phone No")]
        [StringLength(11,ErrorMessage ="Phone Number Must Be 11 Number")]
        public string PhoneNo { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Governorate { get; set; }
        public DateTime OrderDate { get; set; }= DateTime.Now;
        public virtual List<OrderDetails>? OrderDetails { get; set; } 
    }
}
