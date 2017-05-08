namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;

    public class Product : IDeletableEntity, IAuditInfo
    {
        private ICollection<Item> items;
        private ICollection<Review> reviews;

        public Product()
        {
            this.CreatedOn = DateTime.Now;
            this.items = new HashSet<Item>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public bool IsInStock { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}
