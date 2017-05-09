namespace Store.Services.Contracts
{
    using Models.EntityModels;
    using Common;
    using Models.ViewModels.Product;
    using System.Linq;
    using Models.ViewModels.ShoppingCart;

    public interface IProductService : IBaseDataService<Product>
    {
        CreateProductViewModel PrepareModel();

        Product MapCategoryAndSupplierByName(Product currentProduct, EditProductViewModel viewModel);

        IQueryable<Product> AllProductsInStock();

        void GetProductPriceAndName(ItemViewModel viewModel);
    }
}
