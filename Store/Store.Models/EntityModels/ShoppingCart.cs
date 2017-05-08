namespace Store.Models.EntityModels
{
    using System;
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class ShoppingCart : IDeletableEntity, IAuditInfo
    {
        private List<Item> items;

        public ShoppingCart()
        {
            this.CreatedOn = DateTime.Now;
            this.items = new List<Item>();
        }

        [ForeignKey("Purchase")]
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }

        public virtual Purchase Purchase { get; set; }

        public List<Item> Items
        {
            get { return this.items; }
            set { this.items = value; }
        }
    }
}
