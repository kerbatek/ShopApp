using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    [Table("Tracking", Schema = "ShopDB")]
    public class Tracking
    {
        [Key]
        public int TrackingID { get; set; }

        [MaxLength(50)]
        public string Carrier { get; set; }

        [MaxLength(50)]
        public string Service { get; set; } 

        [MaxLength(20)]
        public string TrackingStatus { get; set; }

        public DateTime? EstimatedDeliveryDate { get; set; }

        [MaxLength(255)]
        public string TrackingUrl { get; set; }

        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}