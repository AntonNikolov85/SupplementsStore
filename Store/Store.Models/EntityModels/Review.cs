namespace Store.Models.EntityModels
{
    using System;
    using Common;

    public class Review : IAuditInfo, IDeletableEntity
    {
        public Review()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Oppinion { get; set; }

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
