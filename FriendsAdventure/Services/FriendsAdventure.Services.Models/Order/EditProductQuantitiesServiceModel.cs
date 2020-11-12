namespace FriendsAdventure.Services.Models.Order
{
    public class EditProductQuantitiesServiceModel
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
    }
}
