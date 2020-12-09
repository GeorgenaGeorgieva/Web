namespace FriendsAdventure.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ProductQuantity
    {
        [Key]
        public int Id { get; set; }

        public int Quantity { get; set; }


        public int ProductId { get; set; }

        public Product Product { get; set; }


        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}
