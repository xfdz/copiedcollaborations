﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;


namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get
            {
                return context.Products;
            }
        }
    }
}
