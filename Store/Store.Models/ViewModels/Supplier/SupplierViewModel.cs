namespace Store.Models.ViewModels.Supplier
{
    using EntityModels;
    using Infrastructure.Mapping;

    public class SupplierViewModel : IMapFrom<Supplier>, IMapTo<Supplier>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }
    }
}
