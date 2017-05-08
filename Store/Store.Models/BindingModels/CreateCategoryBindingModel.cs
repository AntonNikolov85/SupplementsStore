namespace Store.Models.BindingModels
{
    using EntityModels;
    using Infrastructure.Mapping;

    public class CreateCategoryBindingModel : IMapTo<Category>
    {
        public string Name { get; set; }
    }
}
