using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Models
{
    [Table("ProductCategories", Schema = "ShopDB")]
    public class ProductCategory
    {
        [Key, Column(Order = 0)]
        public int ProductID { get; set; }

        [Key, Column(Order = 1)]
        public int CategoryID { get; set; }

        public DateTime? AssignedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }

        [ForeignKey(nameof(CategoryID))]
        public Category Category { get; set; }
    }
}