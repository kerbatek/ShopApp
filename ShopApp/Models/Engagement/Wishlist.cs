using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.Core;

namespace ShopApp.Models.Engagement
{
    [Table("Wishlist", Schema = "ShopDB")]
    public class Wishlist
    {
        [Key]
        public int WishlistID { get; set; }

        public int UserID { get; set; }

        [MaxLength(20)]
        public string WishlistName { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<WishlistItem> WishlistItems { get; set; }

        public ApplicationUser User { get; set; }
    }
}