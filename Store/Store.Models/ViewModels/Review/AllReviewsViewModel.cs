namespace Store.Models.ViewModels.Review
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;

    public class AllReviewsViewModel : IMapTo<Review>, IMapFrom<Review>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Oppinion { get; set; }

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
