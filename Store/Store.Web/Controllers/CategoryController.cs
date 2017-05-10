namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Models.BindingModels;
    using Models.EntityModels;
    using Models.ViewModels.Category;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("category")]
    [Authorize(Roles ="Admin")]
    public class CategoryController : BaseController
    {
        private ICategoryService categoryService;

        public CategoryController(ICategoryService service)
        {
            this.categoryService = service;
        }


        // GET: Index
        [HttpGet]
        [Route("index")]
        public ActionResult Index()
        {
            return this.View();
        }

        // GET: Category
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public ActionResult All()
        {
            var allCategories = this.categoryService.GetAll().To<CategoryViewModel>().ToList();

            return View(allCategories);
        }

        // GET: Category/Create
        [HttpGet]
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [Route("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] CreateCategoryBindingModel bindingModel)
        {

            Category category = this.Mapper.Map<Category>(bindingModel);

            if (ModelState.IsValid)
            {
                this.categoryService.Add(category);
                return RedirectToAction("all");
            }

            return View(bindingModel);
        }

        // GET: Category/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            Category categoryFromDb = this.categoryService.GetById(id);
            CategoryViewModel categoryToEdit = this.Mapper.Map<CategoryViewModel>(categoryFromDb);

            return View(categoryToEdit);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] CategoryViewModel viewModel)
        {
            Category category = this.Mapper.Map<Category>(viewModel);

            if (ModelState.IsValid)
            {
                this.categoryService.Edit(category);
                return this.RedirectToAction("all");
            }

            return View(viewModel);
        }

        // GET: Category/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Category categoryFromDb = this.categoryService.GetById(id);
            CategoryViewModel categoryToDelete = this.Mapper.Map<CategoryViewModel>(categoryFromDb);

            return View(categoryToDelete);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("delete")]
        [Route("delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.categoryService.Delete(id);

            return RedirectToAction("all");
        }
    }
}
