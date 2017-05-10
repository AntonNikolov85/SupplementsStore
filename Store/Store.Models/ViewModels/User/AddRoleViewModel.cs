namespace Store.Models.ViewModels.User
{
    using Infrastructure.Mapping;
    using EntityModels;
    using System.ComponentModel.DataAnnotations;

    public class AddRoleViewModel : IMapFrom<ApplicationUser>
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

        [Required]
        public string RoleName { get; set; }
    }
}
