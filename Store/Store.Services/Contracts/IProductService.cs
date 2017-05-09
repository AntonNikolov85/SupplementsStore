namespace Store.Services.Contracts
{
    using Models.EntityModels;
    using Common;
    using Models.ViewModels.Product;

    public interface IProductService : IBaseDataService<Product>
    {
        CreateProductViewModel PrepareModel();

        Product MapCategoryAndSupplierByName(Product currentProduct, EditProductViewModel viewModel);
    }
}
