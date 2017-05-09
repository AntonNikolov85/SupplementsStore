namespace Store.Services.Contracts
{
    using Common;
    using Models.EntityModels;

    public interface IUserService : IBaseDataService<ApplicationUser>
    {
        void AddRoleToUser(ApplicationUser user, string roleName);
    }
}
