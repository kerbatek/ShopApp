using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    [Table("Inventory", Schema = "ShopDB")]
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public DateTime? DeletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}