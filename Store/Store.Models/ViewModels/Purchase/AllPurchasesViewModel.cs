namespace Store.Models.ViewModels.Purchase
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class AllPurchasesViewModel : IMapFrom<Purchase>
    {
        public int Id { get; set; }

        [Range(1, 999.999, ErrorMessage = "You are not allowed to buy products with such high Total Price")]
        public decimal TotalPrice { get; set; }
    }
}
