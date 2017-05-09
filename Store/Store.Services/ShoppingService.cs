namespace Store.Services
{
    using Common;
    using Contracts;
    using Models.EntityModels;
    using Data.Common;
    using Models.ViewModels.ShoppingCart;
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure.Mapping;

    public class ShoppingService : BaseDataService<ShoppingCart>, IShoppingService
    {
        private IDbRepository<Item> itemRepo;
        private IDbRepository<ShoppingCart> shoppingCartRepo;
        private IDbRepository<Purchase> purchaseRepo;

        public ShoppingService(IDbRepository<ShoppingCart> dataSet, IDbRepository<Purchase> purchaseDataSet, IDbRepository<Item> itemDataSet, IDbRepository<ShoppingCart> shoppingCartDataSet)
            : base(dataSet)
        {
            this.purchaseRepo = purchaseDataSet;
            this.itemRepo = itemDataSet;
            this.shoppingCartRepo = shoppingCartDataSet;
        }


        public Purchase CreatePurchaseWithCart(List<ItemViewModel> cartItems)
        {
            List<Item> currentItems = cartItems.AsQueryable().To<Item>().ToList();

            // save items
            foreach (var item in currentItems)
            {
                this.itemRepo.Add(item);
                this.itemRepo.Save();
            }

            // save purchase
            Purchase purchase = new Purchase()
            {
                TotalPrice = cartItems.Sum(i => i.Quantity * i.Price),
                ShoppingCart = new ShoppingCart()
                {
                    Items = currentItems
                }
            };

            this.purchaseRepo.Add(purchase);
            this.purchaseRepo.Save();

            return purchase;
        }

        public ItemViewModel CreateItem(ShoppingProductViewModel viewModel)
        {
            ItemViewModel model = new ItemViewModel()
            {
                ProductId = viewModel.Id,
                Quantity = viewModel.Quantity
            };

            return model;
        }
    }
}
