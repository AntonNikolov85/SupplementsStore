namespace Store.Models.ViewModels.Product
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateProductViewModel : IMapTo<Product>
    {
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

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Suppliers { get; set; }
    }
}
