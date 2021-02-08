namespace FriendsAdventure.WebApp.Models.Orders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using FriendsAdventure.Services.Models.Product;

    public class AddProductToOrderViewModel
    {
        public int OrderId { get; set; }

        [Range(1, int.MaxValue)]
        [Display( Name = "Продукт")]
        public int ProductId { get; set; }

        [Display(Name ="Количество")]
        public int Quantity { get; set; }
        
        public IEnumerable<ProductListingServiceModel> DataProducts { get; set; }
    }
}
