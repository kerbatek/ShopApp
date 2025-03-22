using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    [Table("Payments", Schema = "ShopDB")]
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        public int UserID { get; set; }
        public DateTime PaymentDate { get; set; }

        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(20)]
        public string PaymentStatus { get; set; } 

        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ApplicationUser User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}