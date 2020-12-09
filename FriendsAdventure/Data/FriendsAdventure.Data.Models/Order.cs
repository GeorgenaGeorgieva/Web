namespace FriendsAdventure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        public Order()
        {
            this.ProductQuantities = new List<ProductQuantity>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public bool IsDeleted { get; set; }

        public ICollection<ProductQuantity> ProductQuantities { get; set; } 
   }
}
