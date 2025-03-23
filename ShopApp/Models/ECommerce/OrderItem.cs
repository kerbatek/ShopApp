using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.Catalog;

namespace ShopApp.Models.ECommerce
{
    [Table("OrderItems", Schema = "ShopDB")]
    public class OrderItem
    {
        [Key]
        public int OrderItemID { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ProductPrice { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}