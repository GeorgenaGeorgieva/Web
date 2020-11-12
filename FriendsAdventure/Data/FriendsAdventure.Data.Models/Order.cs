namespace FriendsAdventure.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductQuantity> ProductsQuantities { get; set; } = new List<ProductQuantity>();
   }
}
