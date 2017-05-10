namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Supplier : IAuditInfo, IDeletableEntity
    {
        private ICollection<Product> products;

        public Supplier()
        {
            this.CreatedOn = DateTime.Now;
            this.products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 12, ErrorMessage = "Name must be between 12 and 20 characters")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Country name can not more than 30 characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Town name can nott more than 20 characters")]
        public string Town { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address can not more than 50 characters")]
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
