using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ShopApp.Models.Catalog;

namespace ShopApp.Models.Engagement
{
    [Table("WishlistItems", Schema = "ShopDB")]
    [PrimaryKey(nameof(WishlistID))]
    public class WishlistItem
    {
        [Key, Column(Order = 0)]
        public int WishlistID { get; set; }

        [Key, Column(Order = 1)]
        public int ProductID { get; set; }

        public DateTime? AddedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(WishlistID))]
        public Wishlist Wishlist { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}