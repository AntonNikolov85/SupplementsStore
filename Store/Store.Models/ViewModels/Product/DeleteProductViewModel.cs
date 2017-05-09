namespace Store.Models.ViewModels.Product
{
    using AutoMapper;
    using EntityModels;
    using Infrastructure.Mapping;

    public class DeleteProductViewModel : IMapFrom<Product>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string SupplierName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Product, ProductViewModel>().ForMember(p => p.CategoryName, opt => opt.MapFrom(p => p.Category.Name));
            configuration.CreateMap<Product, ProductViewModel>().ForMember(p => p.SupplierName, opt => opt.MapFrom(p => p.Supplier.Name));
        }
    }
}
