using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using SportsStore.WebUI.Models;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel productList = new ProductsListViewModel();
            int itemSkipped = (page - 1) * PageSize;
            bool isNullCategory = String.IsNullOrEmpty(category);

            // query data source -LINQ to SQL
            productList.Products = repository.Products
                .Where(p => p.Category == category || isNullCategory)
                .OrderBy(p => p.ProductID)
                .Skip(itemSkipped)        
                .Take(PageSize);                    
            
            // get paging information
            int totalItems = ( category == null )
              ? repository.Products.Count() 
              : repository.Products.Where(e => e.Category == category).Count();
             

            productList.PagingInfo = new PagingInfo
            {   
                CurrentPage = page,
                ItemsPerPage= PageSize,
                TotalItems  = totalItems
            };

            // get Category
            productList.CurrentCategory = category;

            return View(productList);
        }


        #region Fields

        public int PageSize = 4;
        private IProductRepository repository;

        #endregion
    }
}
