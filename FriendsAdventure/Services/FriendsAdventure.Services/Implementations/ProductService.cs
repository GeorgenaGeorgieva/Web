namespace FriendsAdventure.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using FriendsAdventure.Data;
    using FriendsAdventure.Data.Models;
    using FriendsAdventure.Services.Implementations.Validations;
    using FriendsAdventure.Services.Models.Product;
    using FriendsAdventure.Services.Models.ProductQuantities;

    public class ProductService : IProductService
    {
        private const int ProductPageSize = 5;
        private readonly FriendsAdventureDbContext data;

        public ProductService(FriendsAdventureDbContext data)
            =>this.data = data;

        public IEnumerable<ProductListingServiceModel> All(int page = 1)
            => this.data.Products
            .Skip((page - 1) * ProductPageSize)
            .Take(ProductPageSize)
            .Select(p => new ProductListingServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
            })
            .OrderBy(p => p.Name)
            .ToList();

        public void Create(CreateProductServiceModel model)
        {
            Validator.NameValidate(model.Name);
            Validator.DescriptionValidate(model.Description);

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();
        }

        public DetailsProductServiceModel Details(int id)
            =>this.data.Products
            .Where(p => p.Id == id)
            .Select(p => new DetailsProductServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })
            .FirstOrDefault();
       
        public void Edit(EditProductServiceModel model)
        {
            Validator.NameValidate(model.Name);
            Validator.DescriptionValidate(model.Description);

            var product = this.data.Products.Find(model.Id);

            product.Name = model.Name;
            product.Description = model.Description;

            this.data.SaveChanges();
        }

        public bool Delete(int id)
        {
            var product = this.data.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            this.data.Products.Remove(product);
            this.data.SaveChanges();

            return true;
        }

        public bool Exists(int id)
            => this.data.Products.Any(p => p.Id == id);

        public IEnumerable<ProductListingServiceModel> ListingProducts()
        => this.data.Products
            .Select(p => new ProductListingServiceModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description
            })
            .OrderBy(p => p.Name)
            .ToList();

        public int Total()
            => this.data.Products.Count();

        public IDictionary<int, ProductQuantitiesServiceModel> GroupedProducts(ICollection<ProductQuantitiesServiceModel> products)
        {
            var groupedProducts = new Dictionary<int, ProductQuantitiesServiceModel>();

            foreach (var product in products)
            {
                if (!groupedProducts.ContainsKey(product.ProductId))
                {
                    groupedProducts[product.ProductId] = product;
                }
                else
                {
                    groupedProducts[product.ProductId].Quantity += product.Quantity;
                    if(groupedProducts[product.ProductId].Quantity <= 0)
                    {
                        groupedProducts.Remove(product.ProductId);
                    }
                }
            }

            return groupedProducts;
        }
    }
}
