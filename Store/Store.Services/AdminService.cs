namespace Store.Services
{
    using Common;
    using Contracts;
    using Models.EntityModels;
    using Data.Common;

    public class AdminService : BaseDataService<ApplicationUser>, IAdminService
    {
        public AdminService(IDbRepository<ApplicationUser> dataSet)
            : base(dataSet)
        {
        }
    }
}
