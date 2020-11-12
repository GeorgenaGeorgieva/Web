namespace FriendsAdventure.Services
{
    using System.Collections.Generic;
    using FriendsAdventure.Data.Models;
    using FriendsAdventure.Services.Models.Order;

    public interface IOrderService
    {
        void Create();
        Order FindById(int id);
        IEnumerable<ListingOrderServicesModel> All(int page = 1);
        int Total();
        DetailsOrderServiceModel Details(int id);
        void AddProductToOrderList(AddProductToOrderServiceModel model);
        bool Exists(int id);
        bool Delete(int id);
    }
}
