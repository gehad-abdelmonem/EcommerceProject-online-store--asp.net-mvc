using System.ComponentModel;

namespace EcommerceProject.Models
{
    public class ProductType
    {
        public int Id { get; set; }

        [DisplayName("Product Type")]
        public string ProductTypeName { get; set; }
        public virtual List<Products>? Products { get; set; }
    }
}
