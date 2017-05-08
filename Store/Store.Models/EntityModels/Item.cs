namespace Store.Models.EntityModels
{
    using System;
    using Common;

    public class Item : IDeletableEntity, IAuditInfo
    {
        public Item()
        {
            this.CreatedOn = DateTime.Now;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}
