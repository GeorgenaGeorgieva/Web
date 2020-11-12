namespace FriendsAdventure.WebApp.Controllers
{
    using System.Linq;
    using FriendsAdventure.Services;
    using FriendsAdventure.Services.Models.Order;
    using FriendsAdventure.WebApp.Models.Orders;
    using Microsoft.AspNetCore.Mvc;
    public class OrdersController : Controller
    {
        private readonly IOrderService orders;
        private readonly IProductService products;

        public OrdersController(IOrderService orders, IProductService products)
        {
            this.orders = orders;
            this.products = products;
        }

        public IActionResult All(int page = 1)
        {
            var orders = this.orders.All(page);
            var total = this.orders.Total();

            var model = new AllOrdersViewModel
            {
                Orders = orders,
                Total = total,
                CurrentPage = page
            };

            return this.View(model);
        }

        public IActionResult Create()
        {
            this.orders.Create();
            return this.RedirectToAction("All", "Orders");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var deleted = this.orders.Delete(id);

            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var orderDetails = this.orders.Details(id);
            var groupedProductsList = this.products.GroupedProducts(orderDetails.ProductQuantities);

            if (orderDetails == null)
            {
                return this.BadRequest();
            }

            var detailsOrderViewModel = new DetailsOrderViewModel
            {
                Id = orderDetails.Id,
                Date = orderDetails.Date,
                Products = groupedProductsList,
            };

            return this.View(detailsOrderViewModel);
        }

        [HttpGet]
        public IActionResult AddingProduct(int orderId)
        {
            if (!this.orders.Exists(orderId))
            {
                return this.BadRequest();
            }

            var order = this.orders.FindById(orderId);
            var dataProducts = this.products.ListingProducts();

            var addProductToOrderViewModel = new AddProductToOrderViewModel
            {
                OrderId = order.Id,
                DataProducts = dataProducts
            };

            return this.View(addProductToOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddingProduct(AddProductToOrderInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var addProductToOrderServiceModel = new AddProductToOrderServiceModel
            {
                OrderId = model.OrderId,
                ProductName = model.ProductName,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            this.orders.AddProductToOrderList(addProductToOrderServiceModel);
            return this.RedirectToAction("Details", "Orders", new { id = model.OrderId });
        }
    }
}
