using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ProductSite.Domain.Entities;

namespace ProductSite.Domain.Concrete
{
    public  class EFDbContext :DbContext
    {
        public DbSet<Product> Products { get; set; }        
    }
}
