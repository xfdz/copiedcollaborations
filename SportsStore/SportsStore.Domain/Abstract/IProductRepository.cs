using System;
using System.Linq;
using System.Data.Entity;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        /// <Remark>
        /// Repository Patterns
        /// </Remark>
        IQueryable<Entities.Product> Products { get; }
    }
}
