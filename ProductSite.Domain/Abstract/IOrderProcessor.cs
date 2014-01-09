using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProductSite.Domain.Entities;

namespace ProductSite.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails); 
    }
}
