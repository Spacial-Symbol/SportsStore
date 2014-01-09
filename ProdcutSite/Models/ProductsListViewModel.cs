using System.Collections.Generic;
using ProductSite.Domain.Entities;

namespace ProdcutSite.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }   
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCatagory { get; set; }
    }
}
