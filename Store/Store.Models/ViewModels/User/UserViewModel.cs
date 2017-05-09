namespace Store.Models.ViewModels.User
{
    using AutoMapper;
    using Enums;
    using Infrastructure.Mapping;
    using EntityModels;

    public class UserViewModel : IMapTo<ApplicationUser>, IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public RoleType RoleName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>().ForMember(u => u.Username, opt => opt.MapFrom(u => u.UserName));
        }
    }
}
