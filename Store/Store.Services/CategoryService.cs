namespace Store.Services
{
    using Contracts;
    using Common;
    using Models.EntityModels;
    using Data.Common;

    public class CategoryService : BaseDataService<Category>, ICategoryService
    {
        public CategoryService(IDbRepository<Category> dataSet)
            : base(dataSet)
        {
        }
    }
}
