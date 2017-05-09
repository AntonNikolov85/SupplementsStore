namespace Store.Models.ViewModels.User
{
    using Infrastructure.Mapping;
    using EntityModels;

    public class AddRoleViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }
    }
}
