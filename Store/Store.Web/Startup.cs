using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Store.Data;
using Store.Models.EntityModels;

[assembly: OwinStartupAttribute(typeof(Store.Web.Startup))]
namespace Store.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            StoreDbContext context = new StoreDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            //creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admin"))
            {

                //create Admin role   
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //create a Admin super user who will maintain the website                  
                var user = new ApplicationUser();
                user.UserName = "toniN";
                user.Name = "Antonio";
                user.Email = "antonio@abv.bg";

                string userPassword = "An123$";

                var chkUser = UserManager.Create(user, userPassword);

                //add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            //creating Creating Moderator role    
            if (!roleManager.RoleExists("Moderator"))
            {
                var role = new IdentityRole();
                role.Name = "Moderator";
                roleManager.Create(role);

            }

            //creating Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }
        }
    }
}
