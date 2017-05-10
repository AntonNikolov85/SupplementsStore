namespace Store.Web.Controllers
{
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Models.EntityModels;
    using Models.ViewModels.Review;
    using Services.Contracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    [RoutePrefix("review")]
    [Authorize]
    public class ReviewController : BaseController
    {
        private IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
        {
            this.reviewService = reviewService;
        }


        // GET: Review
        [HttpGet]
        [Route("all/{id}")]
        [AllowAnonymous]
        public ActionResult All(int id)
        {
            IEnumerable<AllReviewsViewModel> reviews = this.reviewService.GetAllReviewsForProduct(id).To<AllReviewsViewModel>().ToList();
            this.reviewService.GetUserForReview(reviews);

            return View(reviews);
        }

        // GET: Review/Create/5
        [HttpGet]
        [Route("create/{id}")]
        public ActionResult Create(int id)
        {
            ReviewViewModel viewModel = new ReviewViewModel()
            {
                ProductId = id
            };

            return View(viewModel);
        }

        // POST: Review/Create/5
        [HttpPost]
        [Route("create/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Oppinion, Rating, ProductId")] ReviewViewModel viewModel)
        {
            Review review = this.Mapper.Map<Review>(viewModel);
            review.ApplicationUserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                this.reviewService.Add(review);
                return this.RedirectToAction("Details", "Product", new { id = viewModel.ProductId });
            }

            return this.View(viewModel);
        }

        // GET: Review/Edit/5
        [HttpGet]
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            Review modelFromDb = this.reviewService.GetById(id);
            AllReviewsViewModel viewModel = this.Mapper.Map<AllReviewsViewModel>(modelFromDb);

            return View(viewModel);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Oppinion, Rating")] AllReviewsViewModel viewModel)
        {
            Review review = this.reviewService.GetReviewFromViewModel(viewModel);

            if (ModelState.IsValid)
            {
                this.reviewService.Edit(review);
                return this.RedirectToAction("All", new { id = review.ProductId });
            }

            return this.View("Edit", new { id = viewModel.Id });
        }

        // GET: Review/Delete/5
        [HttpGet]
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            Review reviewFromDb = this.reviewService.GetById(id);
            AllReviewsViewModel reviewToDelete = this.Mapper.Map<AllReviewsViewModel>(reviewFromDb);

            return View(reviewToDelete);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("delete")]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Review reviewFromDb = this.reviewService.GetById(id);

            this.reviewService.Delete(id);

            return RedirectToAction("All", new { id = reviewFromDb.ProductId });
        }
    }
}
