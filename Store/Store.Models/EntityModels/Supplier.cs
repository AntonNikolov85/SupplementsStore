namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;

    public class Supplier : IAuditInfo, IDeletableEntity
    {
        private ICollection<Product> products;

        public Supplier()
        {
            this.CreatedOn = DateTime.Now;
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
