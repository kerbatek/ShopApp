﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Models
{
    [Table("Carts", Schema = "ShopDB")]
    public class Cart
    {
        [Key]
        public int CartID { get; set; }
        public string UserID { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } 

        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public ICollection<CartItem> CartItems { get; set; }

        [ForeignKey(nameof(UserID))]
        public ApplicationUser User { get; set; }
    }
}