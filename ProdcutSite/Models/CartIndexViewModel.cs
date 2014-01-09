using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductSite.Domain.Entities;

namespace ProdcutSite.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; } 
        public string ReturnUrl { get; set; }         
    }
}