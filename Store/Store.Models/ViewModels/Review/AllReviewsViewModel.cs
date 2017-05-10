namespace Store.Models.ViewModels.Review
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class AllReviewsViewModel : IMapTo<Review>, IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Oppinion can not more than 50 characters")]
        public string Oppinion { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public string ApplicationUserId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ApplicationUserName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Review, AllReviewsViewModel>().ForMember(r => r.ApplicationUserName, opt => opt.MapFrom(r => r.User.UserName));
            configuration.CreateMap<Review, AllReviewsViewModel>().ForMember(r => r.ProductName, opt => opt.MapFrom(r => r.Product.Name));
        }
    }
}
