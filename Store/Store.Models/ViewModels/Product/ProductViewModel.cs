namespace Store.Models.ViewModels.Product
{
    using AutoMapper;
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ProductViewModel : IMapFrom<Product>, IMapTo<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Oppinion can not more than 50 characters")]
        public string Description { get; set; }

        public string Url { get; set; }

        [Range(1, 99.99, ErrorMessage = "Price must be between 1 and 99.99")]
        public decimal Price { get; set; }

        [Required]
        public bool IsInStock { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
            configuration.CreateMap<Product, ProductViewModel>().ForMember(p => p.SupplierName, opt => opt.MapFrom(p => p.Supplier.Name));
        }
    }
}
