using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceProject.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public String Image { get; set; }

        [DisplayName("Product Color")]
        public string ProductColor { get; set; }

        [DisplayName("Available")]
        public bool IsAvailable { get; set; }
        [ForeignKey("ProductTyp")]
        [DisplayName("ProductType")]
        public int ProductTypId { get; set; }
        public virtual ProductType? ProductTyp { get; set; }
    }
}
