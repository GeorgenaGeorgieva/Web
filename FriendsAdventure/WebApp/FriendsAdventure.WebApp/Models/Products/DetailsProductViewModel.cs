namespace FriendsAdventure.WebApp.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    public class DetailsProductViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Продукт")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
