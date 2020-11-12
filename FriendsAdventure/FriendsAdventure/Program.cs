namespace FriendsAdventure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FriendsAdventure.Data;
    using FriendsAdventure.Data.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            using(var data = new FriendsAdventureDbContext())
            {
                //    var order = data.Orders.Where(o => o.Id == 39).FirstOrDefault();
                //    var product = data.Products.Where(p => p.Id == 56).FirstOrDefault();

                //    var productQuantity = new ProductQuantity
                //    {
                //        ProductId = product.Id,
                //        Product=product,
                //        Quantity=6
                //    };

                //order.ProductsQuantityes.Add(productQuantity);
                //data.SaveChanges();

                //for (int i = 0; i < 50; i++)
                //{
                //    var product = new Product
                //    {
                //        Name = "Product " + i,
                //        Quantity = 0
                //    };

                //    data.Products.Add(product);
                //}
                //data.SaveChanges();

                //    for (int i = 0; i < 1; i++)
                //    {
                //        var order = new Order
                //        {
                //            Date = DateTime.UtcNow,
                //            Products = new List<ProductOrder>()
                //            {
                //                new ProductOrder { ProductId = 56},
                //                new ProductOrder { ProductId = 57}
                //            }
                //        };

                //        data.Orders.Add(order);
                //    }
                //    data.SaveChanges();

                //var order = data.Orders.Where(o => o.Id == 34).FirstOrDefault();
                //var product = data.Products.Where(p => p.Id == 56).FirstOrDefault();

                //order.Products.Add(new ProductOrder { Product = product, ProductId = product.Id});
                //data.SaveChanges();
            }
        }
    }
}
