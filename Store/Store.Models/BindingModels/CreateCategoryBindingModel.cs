namespace Store.Models.BindingModels
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryBindingModel : IMapTo<Category>
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }
    }
}
