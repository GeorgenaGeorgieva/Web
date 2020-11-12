namespace FriendsAdventure.WebApp.Controllers
{
    using FriendsAdventure.Services;
    using FriendsAdventure.Services.Models.Product;
    using FriendsAdventure.WebApp.Models.Products;
    using Microsoft.AspNetCore.Mvc;
    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
            => this.products = products;

        public IActionResult All(int page = 1)
        {
            var products = this.products.All(page);
            var total = this.products.Total();

            var model = new AllProductsViewModel
            {
                Products = products,
                Total = total,
                CurrentPage = page
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var createProductServiceModel = new CreateProductServiceModel
            {
                Name = model.Name,
                Description = model.Description
            };

            this.products.Create(createProductServiceModel);
            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            if (!this.products.Exists(id))
            {
                return this.NotFound();
            }

            var detailsProductServiceModel = this.products.Details(id);

            var detailsProductViewModel = new DetailsProductViewModel
            {
                Id = detailsProductServiceModel.Id,
                Name = detailsProductServiceModel.Name,
                Description = detailsProductServiceModel.Description,
            };

            return this.View(detailsProductViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!this.products.Exists(id))
            {
                return this.NotFound();
            }

            var detailsProductServiceModel = this.products.Details(id);

            var editProductInputModel = new EditProductInputModel
            {
                Id = detailsProductServiceModel.Id,
                Name = detailsProductServiceModel.Name,
                Description = detailsProductServiceModel.Description
            };

            return this.View(editProductInputModel);
        }

        [HttpPost]
        public IActionResult Edit(EditProductInputModel model)
        {
            if (!this.products.Exists(model.Id))
            {
                return this.BadRequest();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var editProductServiceModel = new EditProductServiceModel
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            this.products.Edit(editProductServiceModel);
            return this.RedirectToAction("All", "Products");
        }

        public IActionResult Delete(int id)
        {
            var deleted = this.products.Delete(id);

            if (!deleted)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("All");
        }
    }
}
