﻿using System.ComponentModel.DataAnnotations;

namespace DarsBakeryv3.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Cake Cake { get; set; }
        public int Amount { get; set; }


        public string ShoppingCartId { get; set; }
    }
}
