namespace FriendsAdventure.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Product
    {
        public Product()
        {
            this.ProductQuantities = new HashSet<ProductQuantity>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(3)]
        public string Description { get; set; }

        public ICollection<ProductQuantity> ProductQuantities { get; set; }
    }
}
