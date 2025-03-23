using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models.Catalog
{
    [Table("Categories", Schema = "ShopDB")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [MaxLength(50)]
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}