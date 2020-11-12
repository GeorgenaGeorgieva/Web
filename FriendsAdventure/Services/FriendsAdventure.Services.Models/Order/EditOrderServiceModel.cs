namespace FriendsAdventure.Services.Models.Order
{
    using System.Collections.Generic;
    using FriendsAdventure.Data.Models;
    using FriendsAdventure.Services.Models.Product;

    public class EditOrderServiceModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public ICollection<ProductQuantity> ProductQuantities { get; set; }

    }
}
