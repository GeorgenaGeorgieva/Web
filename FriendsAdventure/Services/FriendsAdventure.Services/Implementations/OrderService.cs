namespace FriendsAdventure.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FriendsAdventure.Data;
    using FriendsAdventure.Data.Models;
    using FriendsAdventure.Services.Implementations.Validations;
    using FriendsAdventure.Services.Models.Order;
    using FriendsAdventure.Services.Models.ProductQuantities;

    public class OrderService : IOrderService
    {
        private const int OrderPageSize = 5;
        private readonly FriendsAdventureDbContext data;
        public OrderService(FriendsAdventureDbContext data)
        {
            this.data = data;
        }

        public void Create()
        {
            var order = new Order
            {
                Date = DateTime.UtcNow,
                ProductsQuantities = new List<ProductQuantity>()
            };

            this.data.Orders.Add(order);
            this.data.SaveChanges();
        }

        public void AddProductToOrderList(AddProductToOrderServiceModel model)
        {
            var order = this.data.Orders.Where(o => o.Id == model.OrderId).FirstOrDefault();
            if (order == null)
            {
                throw new ArgumentException("There is no order whith given id.");
            }

            var product = this.data.Products.Where(p => p.Id == model.ProductId).FirstOrDefault();
            if(product == null)
            {
                throw new ArgumentException("There is no product with given id.");
            }

            var productQuantity = new ProductQuantity
            {
                ProductId = model.ProductId,
                Product = product,
                Quantity = model.Quantity,
            };

            order.ProductsQuantities.Add(productQuantity);
            this.data.SaveChanges();
        }

        public IEnumerable<ListingOrderServicesModel> All(int page = 1)
         => this.data.Orders
            .Where(o => o.IsDeleted == false)
            .OrderByDescending(o => o.Date)
            .Skip((page - 1) * OrderPageSize)
            .Take(OrderPageSize)
            .Select(o => new ListingOrderServicesModel
            {
                Id = o.Id, 
                Date = o.Date.ToShortDateString()
            })
            .ToList();

        public DetailsOrderServiceModel Details(int id)
        => this.data
            .Orders
            .Where(o => o.Id == id)
            .Select(o => new DetailsOrderServiceModel
            {
                Id = o.Id,
                Date = o.Date.ToShortDateString(),
                ProductQuantities = o.ProductsQuantities.Select(p => new ProductQuantitiesServiceModel
                {
                    Id = p.Id,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    Quantity = p.Quantity,
                    Description = p.Product.Description
                }).ToList()
            })
            .FirstOrDefault();

        public int Total()
        => this.data.Orders.Where(o => o.IsDeleted == false).Count();

        public Order FindById(int id)
        => this.data
            .Orders
            .Where(o => o.Id == id)
            .Select(o => new Order
            {
                Id = o.Id,
                Date=o.Date,
                ProductsQuantities = o.ProductsQuantities
            })
            .FirstOrDefault();

        public bool Exists(int id)
        => this.data.Orders.Any(o => o.Id == id);

        public bool Delete(int id)
        {
            var order = this.data.Orders.Where(o => o.Id == id).FirstOrDefault();
            if (order == null)
            {
                return false;
            }

            order.IsDeleted = true;
            this.data.SaveChanges();

            return true;
        }
    }
}
