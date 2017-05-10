namespace Store.Models.ViewModels.User
{
    using AutoMapper;
    using Enums;
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel : IMapTo<ApplicationUser>, IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username must be between 5 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public RoleType RoleName { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>().ForMember(u => u.Username, opt => opt.MapFrom(u => u.UserName));
        }
    }
}
