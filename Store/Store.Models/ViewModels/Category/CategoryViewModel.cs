namespace Store.Models.ViewModels.Category
{
    using EntityModels;
    using Infrastructure.Mapping;

    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
