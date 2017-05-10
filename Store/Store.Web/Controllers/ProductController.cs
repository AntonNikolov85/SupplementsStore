namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Models.EntityModels;
    using Models.ViewModels.Product;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("product")]
    [Authorize(Roles="Admin")]
    public class ProductController : BaseController
    {
        private IProductService productService;

        public ProductController(IProductService service)
        {
            this.productService = service;
        }


        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Product
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public ActionResult All()
        {
            var allProducts = this.productService.GetAll().To<ProductViewModel>().ToList();

            return View(allProducts);
        }

        // GET: Product/Details/5
        [HttpGet]
        [Route("details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product productFromDb = this.productService.GetById(id);
            ProductViewModel viewModel = this.Mapper.Map<ProductViewModel>(productFromDb);

            return View(viewModel);
        }

        // GET: Product/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            CreateProductViewModel model = this.productService.PrepareModel();

            return View(model);
        }

        // POST: Product/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "Name, Description, Url, Price, IsInStock, CategoryId, SupplierId")] CreateProductViewModel viewModel)
        {
            Product product = this.Mapper.Map<Product>(viewModel);

            if (ModelState.IsValid)
            {
                this.productService.Add(product);
                return RedirectToAction("all");
            }

            return View(viewModel);
        }

        // GET: Product/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            Product productFromDb = this.productService.GetById(id);
            EditProductViewModel productToEdit = this.Mapper.Map<EditProductViewModel>(productFromDb);

            return View(productToEdit);
        }

        // POST: Product/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Description, Url, Price, Discount, IsInStock, CategoryName, SupplierName")] EditProductViewModel viewModel)
        {
            Product product = this.Mapper.Map<Product>(viewModel);
            product = this.productService.MapCategoryAndSupplierByName(product, viewModel);

            if (ModelState.IsValid)
            {
                this.productService.Edit(product);
                return this.RedirectToAction("all");
            }

            return View(viewModel);
        }

        // GET: Product/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Product productFromDb = this.productService.GetById(id);
            DeleteProductViewModel productToDelete = this.Mapper.Map<DeleteProductViewModel>(productFromDb);

            return View(productToDelete);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("delete")]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            this.productService.Delete(id);

            return RedirectToAction("all");
        }
    }
}
