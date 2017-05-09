namespace Store.Models.ViewModels.Review
{
    using Infrastructure.Mapping;
    using EntityModels;

    public class ReviewViewModel : IMapTo<Review>
    {
        public string Oppinion { get; set; }

        public int Rating { get; set; }

        public int ProductId { get; set; }
    }
}
