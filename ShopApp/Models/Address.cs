using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    [Table("Addresses", Schema = "ShopDB")]
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [MaxLength(100)]
        public string StreetName { get; set; }

        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }

        [MaxLength(20)]
        public string ZipCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        
        public ICollection<UserAddress> UserAddresses { get; set; }
    }
    
}