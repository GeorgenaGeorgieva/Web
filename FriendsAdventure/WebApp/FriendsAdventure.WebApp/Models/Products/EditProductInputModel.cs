namespace FriendsAdventure.WebApp.Models.Products
{
    using System.ComponentModel.DataAnnotations;
    public class EditProductInputModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Display(Name = "Продукт")]
        public string Name { get; set; }

        [MinLength(3)]
        [MaxLength(200)]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}