using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.Catalog;

namespace ShopApp.Models.ECommerce
{
    [Table("CartItems", Schema = "ShopDB")]
    public class CartItem
    {
        [Key]
        public int CartItemID { get; set; }

        public int CartID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(CartID))]
        public Cart Cart { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}