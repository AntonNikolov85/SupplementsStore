namespace Store.Models.ViewModels.Product
{
    using EntityModels;
    using Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class CreateProductViewModel : IMapTo<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public decimal Price { get; set; }

        public bool IsInStock { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public List<SelectListItem> Suppliers { get; set; }
    }
}
