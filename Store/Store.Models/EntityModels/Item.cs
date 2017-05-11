namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Item : IDeletableEntity, IAuditInfo
    {
        public Item()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 20 characters")]
        public string Name { get; set; }

        [Range(1, 99.99, ErrorMessage = "Price must be between 1 and 99.99")]
        public decimal Price { get; set; }

        [Range(1, 10, ErrorMessage = "Quantity must be between 1 and 10")]
        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
