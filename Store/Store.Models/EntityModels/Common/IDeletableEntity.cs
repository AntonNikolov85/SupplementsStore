namespace Store.Models.EntityModels.Common
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}
