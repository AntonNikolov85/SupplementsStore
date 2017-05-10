namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Review : IAuditInfo, IDeletableEntity
    {
        public Review()
        {
            this.CreatedOn = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Oppinion can not more than 50 characters")]
        public string Oppinion { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public string ApplicationUserId { get; set; }

        public int ProductId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Product Product { get; set; }
    }
}
