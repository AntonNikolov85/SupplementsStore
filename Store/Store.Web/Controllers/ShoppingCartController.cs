namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models.EntityModels;
    using Models.ViewModels.Purchase;
    using Models.ViewModels.ShoppingCart;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("shoppingcart")]
    [Authorize]
    public class ShoppingCartController : BaseController
    {
        private IProductService productService;
        private IPurchaseService purchaseService;
        private IShoppingService shoppingService;
        private static List<ItemViewModel> cartItems = new List<ItemViewModel>();

        public ShoppingCartController(IShoppingService shoppingService, IPurchaseService purchaseService, IProductService productService)
        {
            this.shoppingService = shoppingService;
            this.purchaseService = purchaseService;
            this.productService = productService;
        }


        // GET: ShoppingCart
        [HttpGet, ActionName("all")]
        [Route("all")]
        public ActionResult AllProductsForShopping()
        {
            IEnumerable<ShoppingProductViewModel> productsForSell = this.productService.AllProductsInStock()
                .To<ShoppingProductViewModel>().ToList();

            return View(productsForSell);
        }

        public ActionResult Search(string query)
        {
            IEnumerable<ShoppingProductViewModel> productsByName = this.productService.AllProductsInStock().Where(p => p.Name.Contains(query))
                .To<ShoppingProductViewModel>();

            return this.PartialView("_ProductsByName", productsByName);
        }

        // GET: ShoppingCart/Create
        [HttpGet, ActionName("create")]
        [Route("create")]
        public ActionResult CreateShoppingCart()
        {
            Purchase purchase = this.shoppingService.CreatePurchaseWithCart(cartItems);
            PurchaseViewModel viewModel = this.Mapper.Map<PurchaseViewModel>(purchase);

            cartItems.Clear();
            return this.View(viewModel);
        }

        // POST: ShoppingCart/Create
        [HttpPost, ActionName("create")]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateShoppingCart([Bind(Include = "Id, TotalPrice, Country, Town, Address")] PurchaseViewModel viewModel)
        {
            Purchase purchase = this.Mapper.Map<Purchase>(viewModel);
            purchase.ApplicationUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                this.purchaseService.Edit(purchase);
                return this.RedirectToAction("all");
            }

            return this.View(viewModel);
        }

        // GET: ShoppingCart/Add/5
        [HttpGet, ActionName("add")]
        [Route("add/{id}")]
        public ActionResult AddProductToShoppingCart(int id)
        {
            Product productFromDb = this.productService.GetById(id);
            ShoppingProductViewModel productForShopping = this.Mapper.Map<ShoppingProductViewModel>(productFromDb);

            return this.View(productForShopping);
        }

        // POST: ShoppingCart/Add/5
        [HttpPost, ActionName("add")]
        [Route("add/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult AddProductToShoppingCart([Bind(Include = "Id, Price, Quantity")] ItemViewModel viewModel)
        {
            //ItemViewModel model = this.shoppingService.CreateItem(viewModel);
            //this.productService.GetProductPriceAndName(model);
            viewModel.Name = this.productService.GetById(viewModel.Id).Name;

            if (ModelState.IsValid)
            {
                //ItemViewModel model = this.shoppingService.CreateItem(viewModel);
                //this.productService.GetProductPriceAndName(model);
                cartItems.Add(viewModel);

                return this.RedirectToAction("all");
            }


            Product productFromDb = this.productService.GetById(viewModel.Id);
            ShoppingProductViewModel productForShopping = this.Mapper.Map<ShoppingProductViewModel>(productFromDb);

            return View(productForShopping);
            //return View();
        }

        // GET: ShoppingCart/Remove
        [HttpGet, ActionName("remove")]
        [Route("remove/{id}")]
        public ActionResult RemoveProductFromShoppingCart(int id)
        {
            cartItems.RemoveAll(i => i.Id == id);

            return this.RedirectToAction("all");
        }

        // GET: ShoppingCart/Review
        [HttpGet, ActionName("review")]
        [Route("review")]
        public ActionResult ReviewShoppingCart()
        {
            return this.View(cartItems);
        }
    }
}
