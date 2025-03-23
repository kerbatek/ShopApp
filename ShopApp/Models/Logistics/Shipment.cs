using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.ECommerce;

namespace ShopApp.Models.Logistics
{
    [Table("Shipments", Schema = "ShopDB")]
    public class Shipment
    {
        [Key]
        public int ShipmentID { get; set; }

        public int? TrackingID { get; set; }

        [MaxLength(50)]
        public string PackageNumber { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ShippingCost { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }


        [ForeignKey(nameof(TrackingID))]
        public Tracking Tracking { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}