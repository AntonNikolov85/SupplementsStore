namespace Store.Models.ViewModels.User
{
    using Infrastructure.Mapping;
    using EntityModels;

    public class EditUserViewModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUser>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
