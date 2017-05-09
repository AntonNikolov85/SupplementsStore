namespace Store.Models.BindingModels
{
    using EntityModels;
    using Infrastructure.Mapping;

    public class CreateSupplierBindingModel : IMapTo<Supplier>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }
    }
}
