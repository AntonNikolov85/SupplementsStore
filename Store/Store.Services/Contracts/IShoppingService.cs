namespace Store.Services.Contracts
{
    using Common;
    using Models.EntityModels;
    using Models.ViewModels.ShoppingCart;
    using System.Collections.Generic;

    public interface IShoppingService : IBaseDataService<ShoppingCart>
    {
        Purchase CreatePurchaseWithCart(List<ItemViewModel> cartItems);

        ItemViewModel CreateItem(ShoppingProductViewModel viewModel);
    }
}
