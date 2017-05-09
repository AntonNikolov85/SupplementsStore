namespace Store.Services
{
    using Contracts;
    using Models.EntityModels;
    using Common;
    using Data.Common;
    using Models.ViewModels.Product;
    using System.Linq;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Models.ViewModels.ShoppingCart;

    public class ProductService : BaseDataService<Product>, IProductService
    {
        private IDbRepository<Category> categoriesDbRepo;
        private IDbRepository<Supplier> suppliersDbRepo;

        public ProductService(IDbRepository<Product> dataSet, IDbRepository<Category> categoriesDataSet, IDbRepository<Supplier> suppliersDataSet)
            : base(dataSet)
        {
            this.categoriesDbRepo = categoriesDataSet;
            this.suppliersDbRepo = suppliersDataSet;
        }


        public Product MapCategoryAndSupplierByName(Product currentProduct, EditProductViewModel viewModel)
        {
            currentProduct.CategoryId = categoriesDbRepo.All().Where(c => c.Name == viewModel.CategoryName).FirstOrDefault().Id;
            currentProduct.SupplierId = suppliersDbRepo.All().Where(s => s.Name == viewModel.SupplierName).FirstOrDefault().Id;

            return currentProduct;
        }

        public CreateProductViewModel PrepareModel()
        {
            var categoriesWithNameAndId = this.categoriesDbRepo.All().Select(c => new
            {
                Id = c.Id,
                CategoryName = c.Name
            }).ToList();

            var suppliersWithNameAndId = this.suppliersDbRepo.All().Select(s => new
            {
                Id = s.Id,
                SupplierName = s.Name
            }).ToList();

            var model = new CreateProductViewModel()
            {
                Categories = new List<SelectListItem>(),
                Suppliers = new List<SelectListItem>()
            };

            foreach (var category in categoriesWithNameAndId)
            {
                model.Categories.Add(new SelectListItem()
                {
                    Text = category.CategoryName,
                    Value = category.Id.ToString()
                });
            }

            foreach (var supplier in suppliersWithNameAndId)
            {
                model.Suppliers.Add(new SelectListItem()
                {
                    Text = supplier.SupplierName,
                    Value = supplier.Id.ToString()
                });
            }

            return model;
        }

        public IQueryable<Product> AllProductsInStock()
        {
            return this.GetAll().Where(p => p.IsInStock == true);
        }

        public void GetProductPriceAndName(ItemViewModel viewModel)
        {
            Product product = this.GetById(viewModel.ProductId);
            viewModel.Name = product.Name;
            viewModel.Price = product.Price;
        }
    }
}
