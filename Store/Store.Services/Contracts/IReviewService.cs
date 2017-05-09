namespace Store.Services.Contracts
{
    using Common;
    using Models.EntityModels;
    using Models.ViewModels.Review;
    using System.Collections.Generic;
    using System.Linq;

    public interface IReviewService : IBaseDataService<Review>
    {
        IQueryable<Review> GetAllReviewsForProduct(int id);

        void GetUserForReview(IEnumerable<AllReviewsViewModel> reviews);

        Review GetReviewFromViewModel(AllReviewsViewModel viewModel);
    }
}
