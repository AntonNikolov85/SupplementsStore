namespace Store.Models.ViewModels.Supplier
{
    using Infrastructure.Mapping;
    using EntityModels;

    public class DeleteSupplierViewModel : IMapFrom<Supplier>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }
    }
}
