namespace Store.Models.EntityModels
{
    using System;
    using Common;

    public class Purchase : IDeletableEntity, IAuditInfo
    {
        public Purchase()
        {
            this.CreatedOn = DateTime.Now;
            this.DateOfPurchase = DateTime.Now;
        }

        public int Id { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal FinalPrice { get; set; }

        public string Country { get; set; }

        public string Town { get; set; }

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
