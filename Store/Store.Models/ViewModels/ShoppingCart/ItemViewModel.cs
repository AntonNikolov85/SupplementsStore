namespace Store.Models.ViewModels.ShoppingCart
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using System;

    public class ItemViewModel : IMapTo<Item>, IHaveCustomMappings
    {
        public string Name { get; set; }

        //[Range(1, 99.99, ErrorMessage = "Price must be between 1 and 99.99")]
        public decimal Price { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Quantity { get; set; }

        public int Id { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ItemViewModel, Item>().ForMember(i => i.ProductId, opt => opt.MapFrom(i => i.Id));
        }
    }
}
