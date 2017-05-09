namespace Store.Services
{
    using Common;
    using Contracts;
    using Data.Common;
    using Models.EntityModels;
    using System;

    public class SupplierService : BaseDataService<Supplier>, ISupplierService
    {
        public SupplierService(IDbRepository<Supplier> dataSet)
            : base(dataSet)
        {
        }
    }
}
