namespace Store.Services
{
    using Common;
    using Contracts;
    using Models.EntityModels;
    using Data.Common;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using Data;

    public class UserService : BaseDataService<ApplicationUser>, IUserService
    {
        public UserService(IDbRepository<ApplicationUser> dataSet)
            : base(dataSet)
        {
        }


        public void AddRoleToUser(ApplicationUser user, string roleName)
        {
            StoreDbContext context = new StoreDbContext();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            UserManager.AddToRole(user.Id, roleName);
        }
    }
}
