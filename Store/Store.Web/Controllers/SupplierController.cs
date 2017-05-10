namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.Supplier;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("supplier")]
    [Authorize(Roles="Admin")]
    public class SupplierController : BaseController
    {
        private ISupplierService supplierService;

        public SupplierController(ISupplierService service)
        {
            this.supplierService = service;
        }


        // GET: Index
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Supplier
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public ActionResult All()
        {
            var allSuppliers = this.supplierService.GetAll().To<SupplierViewModel>().ToList();

            return View(allSuppliers);
        }

        // GET: Supplier/Details/5
        [HttpGet]
        [Route("details/{id}")]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Supplier supplierFromDb = this.supplierService.GetById(id);
            SupplierViewModel viewModel = this.Mapper.Map<SupplierViewModel>(supplierFromDb);

            return View(viewModel);
        }

        // GET: Supplier/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Email, PhoneNumber, Country, Town, Address")] CreateSupplierBindingModel bindingModel)
        {
            Supplier supplier = this.Mapper.Map<Supplier>(bindingModel);

            if (ModelState.IsValid)
            {
                this.supplierService.Add(supplier);
                return RedirectToAction("all");
            }

            return View(bindingModel);
        }

        // GET: Supplier/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            Supplier supplierFromDb = this.supplierService.GetById(id);
            SupplierViewModel supplierToEdit = this.Mapper.Map<SupplierViewModel>(supplierFromDb);

            return View(supplierToEdit);
        }

        // POST: Supplier/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Email, PhoneNumber, Country, Town, Address")] SupplierViewModel viewModel)
        {
            Supplier supplier = this.Mapper.Map<Supplier>(viewModel);

            if (ModelState.IsValid)
            {
                this.supplierService.Edit(supplier);
                return this.RedirectToAction("all");
            }

            return View(viewModel);
        }

        // GET: Supplier/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Supplier supplierFromDb = this.supplierService.GetById(id);
            DeleteSupplierViewModel supplierToDelete = this.Mapper.Map<DeleteSupplierViewModel>(supplierFromDb);

            return View(supplierToDelete);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("delete")]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.supplierService.Delete(id);

            return RedirectToAction("all");
        }
    }
}
