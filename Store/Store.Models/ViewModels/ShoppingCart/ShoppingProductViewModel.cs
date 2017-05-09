namespace Store.Models.ViewModels.ShoppingCart
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class ShoppingProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

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
