namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Models.ViewModels.Purchase;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("purchase")]
    public class PurchaseController : Controller
    {
        private IPurchaseService purchaseService;

        public PurchaseController(IPurchaseService service)
        {
            this.purchaseService = service;
        }


        // GET: Purchase
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public ActionResult All()
        {
            var allSuppliers = this.purchaseService.GetAll().To<AllPurchasesViewModel>().ToList();

            return View(allSuppliers);
        }

        // GET: Purchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Purchase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
