using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.Core;
using ShopApp.Models.Logistics;

namespace ShopApp.Models.ECommerce
{
    [Table("Orders", Schema = "ShopDB")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int UserID { get; set; }
        public int? PaymentID { get; set; }
        public int? ShipmentID { get; set; }

        public DateTime OrderDate { get; set; }

        [MaxLength(20)]
        public string OrderStatus { get; set; } // Cancelled, Completed

        [Column(TypeName = "decimal(10,2)")]
        public decimal TotalAmount { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        public ICollection<OrderItem> OrderItems { get; set; }

        public ApplicationUser User { get; set; }
        public Payment Payment { get; set; }
        public Shipment Shipment { get; set; }
    }
}