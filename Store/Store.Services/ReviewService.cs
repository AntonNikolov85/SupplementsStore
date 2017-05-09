namespace Store.Services
{
    using Common;
    using Contracts;
    using Models.EntityModels;
    using Data.Common;
    using Models.ViewModels.Review;
    using System.Collections.Generic;
    using System.Linq;

    public class ReviewService : BaseDataService<Review>, IReviewService
    {
        IDbRepository<ApplicationUser> usersRepo;

        public ReviewService(IDbRepository<Review> dataSet, IDbRepository<ApplicationUser> users)
            : base(dataSet)
        {
            this.usersRepo = users;
        }


        public IQueryable<Review> GetAllReviewsForProduct( int id)
        {
            return this.GetAll().Where(r => r.ProductId == id);
        }

        public void GetUserForReview(IEnumerable<AllReviewsViewModel> reviews)
        {
            foreach (var review in reviews)
            {
                review.ApplicationUserName = this.usersRepo.GetById(review.ApplicationUserId).UserName;
            }
        }

        public Review GetReviewFromViewModel(AllReviewsViewModel viewModel)
        {
            Review review = this.GetById(viewModel.Id);
            review.Oppinion = viewModel.Oppinion;
            review.Rating = viewModel.Rating;

            return review;
        }
    }
}
