namespace Store.Models.ViewModels.ShoppingCart
{
    using EntityModels;
    using Infrastructure.Mapping;

    public class ItemViewModel : IMapTo<Item>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
