namespace Store.Models.ViewModels.ShoppingCart
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class ItemViewModel : IMapTo<Item>
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Range(1, 99.99, ErrorMessage = "Price must be between 1 and 99.99")]
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessage = "Quantity must be between 1 and 5")]
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
