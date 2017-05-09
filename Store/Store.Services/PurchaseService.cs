namespace Store.Services
{
    using Common;
    using Contracts;
    using Models.EntityModels;
    using Data.Common;

    public class PurchaseService : BaseDataService<Purchase>, IPurchaseService
    {
        private IDbRepository<Product> productRepo;

        public PurchaseService(IDbRepository<Purchase> dataSet, IDbRepository<Product> repo)
            : base(dataSet)
        {
            this.productRepo = repo;
        }


    }
}
