namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;

    public class Category : IAuditInfo, IDeletableEntity
    {
        private ICollection<Product> products;

        public Category()
        {
            this.CreatedOn = DateTime.Now;
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
