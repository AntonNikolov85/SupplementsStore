namespace Store.Models.ViewModels.Purchase
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;

    public class PurchaseViewModel : IMapFrom<Purchase>, IMapTo<Purchase>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public decimal TotalPrice { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PurchaseViewModel, Purchase>().ForMember(p => p.TotalPrice, opt => opt.Ignore());
            configuration.CreateMap<PurchaseViewModel, Purchase>().ForMember(p => p.CreatedOn, opt => opt.Ignore());
        }
    }
}
