using System;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Collections.Generic;
using SportsStore.Domain.Entities;


namespace SportsStore.Domain.Concrete
{
    /// <summary>
    /// Defines a property for each table that we want to work with. 
    /// The name of the property specifies the table, and the type 
    /// parameter of the DbSet result specifies the model that the 
    /// Entity Framework should use to represent rows in that table. 
    /// </summary>
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products
        {
            get;
            set;
        }
    }
}
