namespace Store.Models.ViewModels.Review
{
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class ReviewViewModel : IMapTo<Review>
    {
        [Required]
        [StringLength(50, ErrorMessage = "Oppinion can not more than 50 characters")]
        public string Oppinion { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public int ProductId { get; set; }
    }
}
