using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models.Core
{
    [Table("UserAddresses", Schema = "ShopDB")]
    public class UserAddress
    {
        [Key, Column(Order = 0)]
        public string UserID { get; set; }

        [Key, Column(Order = 1)]
        public int AddressID { get; set; }

        [MaxLength(50)]
        public string AddressName { get; set; } // (Home, Work, etc.)

        public DateTime? AssignedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [ForeignKey(nameof(AddressID))]
        public Address Address { get; set; }

        [ForeignKey(nameof(UserID))]
        public ApplicationUser ApplicationUser { get; set; }
    }
}