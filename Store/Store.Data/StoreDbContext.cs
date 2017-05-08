namespace Store.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;

    public class StoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public StoreDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static StoreDbContext Create()
        {
            return new StoreDbContext();
        }
    }
}
