namespace Store.Models.ViewModels.ShoppingCart
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingProductViewModel : IMapFrom<Product>, IHaveCustomMappings
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

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        [Range(1, 10, ErrorMessage = "Please enter a quantity between 1 and 10.")]
        public int Quantity { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ShoppingProductViewModel>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
            configuration.CreateMap<Product, ShoppingProductViewModel>().ForMember(p => p.SupplierName, opt => opt.MapFrom(p => p.Supplier.Name));
        }
    }
}
