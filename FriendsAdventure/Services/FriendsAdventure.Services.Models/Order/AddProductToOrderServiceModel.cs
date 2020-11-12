namespace FriendsAdventure.Services.Models.Order
{
    public class AddProductToOrderServiceModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }
    }
}
