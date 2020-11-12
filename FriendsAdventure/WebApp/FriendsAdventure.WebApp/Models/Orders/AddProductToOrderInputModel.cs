namespace FriendsAdventure.WebApp.Models.Orders
{
    public class AddProductToOrderInputModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
