namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

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

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Oppinion can not more than 50 characters")]
        public string Description { get; set; }

        public string Url { get; set; }

        [Range(1, 99.99, ErrorMessage = "Price must be between 1 and 99.99")]
        public decimal Price { get; set; }

        [Required]
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
