namespace FriendsAdventure.Services.Models.Order
{
    using System.Collections.Generic;
    using FriendsAdventure.Services.Models.ProductQuantities;

    public class DetailsOrderServiceModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public ICollection<ProductQuantitiesServiceModel> ProductQuantities {get; set;}
    }
}
