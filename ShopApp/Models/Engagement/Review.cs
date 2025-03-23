using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShopApp.Models.Catalog;
using ShopApp.Models.Core;

namespace ShopApp.Models.Engagement
{
    [Table("Reviews", Schema = "ShopDB")]
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Rating { get; set; }

        public string Comment { get; set; }

        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ApplicationUser User { get; set; }
        [ForeignKey(nameof(ProductID))]
        public Product Product { get; set; }
    }
}