using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EntityCRUD.Models
{
    public class ProductsConnection:DbContext
    {
        public DbSet<Product> ProductsTable { get; set; }
    }
}