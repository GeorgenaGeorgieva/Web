namespace FriendsAdventure.Services
{
    using System.Collections.Generic;
    using FriendsAdventure.Services.Models.Product;
    using FriendsAdventure.Services.Models.ProductQuantities;

    public interface IProductService
    {
        void Create(CreateProductServiceModel model);
        int Total();
        IEnumerable<ProductListingServiceModel> All(int page = 1);
        bool Exists(int id);
        DetailsProductServiceModel Details(int id);
        void Edit(EditProductServiceModel model);
        bool Delete(int id);
        IEnumerable<ProductListingServiceModel> ListingProducts();
        IDictionary<int, ProductQuantitiesServiceModel> GroupedProducts(ICollection<ProductQuantitiesServiceModel> products);
    }
}
