namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Purchase : IDeletableEntity, IAuditInfo
    {
        public Purchase()
        {
            this.CreatedOn = DateTime.Now;
            this.DateOfPurchase = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }

        [Range(1, 999.999, ErrorMessage = "You are not allowed to buy products with such high Total Price")]
        public decimal TotalPrice { get; set; }

        public decimal FinalPrice { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Country name can not more than 30 characters")]
        public string Country { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Town name can nott more than 20 characters")]
        public string Town { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Address can not more than 50 characters")]
        public string Address { get; set; }

        public string Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
