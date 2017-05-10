namespace Store.Models.ViewModels.Purchase
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class PurchaseViewModel : IMapFrom<Purchase>, IMapTo<Purchase>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Range(1, 999.999, ErrorMessage = "You are not allowed to buy products with such high Total Price")]
        public decimal TotalPrice { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Country name can not more than 30 characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Town name can nott more than 20 characters")]
        public string Town { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address can not more than 50 characters")]
        public string Address { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PurchaseViewModel, Purchase>().ForMember(p => p.TotalPrice, opt => opt.Ignore());
            configuration.CreateMap<PurchaseViewModel, Purchase>().ForMember(p => p.CreatedOn, opt => opt.Ignore());
        }
    }
}
