namespace Store.Models.ViewModels.Category
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }
    }
}
