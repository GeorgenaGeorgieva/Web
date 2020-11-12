namespace FriendsAdventure.WebApp.Models.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FriendsAdventure.Services.Models.ProductQuantities;

    public class DetailsOrderViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Дата на поръчката")]
        public string Date { get; set; }
        public IDictionary<int, ProductQuantitiesServiceModel> Products { get; set; }
    }
}
