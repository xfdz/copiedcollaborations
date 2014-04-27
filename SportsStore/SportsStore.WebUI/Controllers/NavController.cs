﻿using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;

using SportsStore.WebUI.Models;
using SportsStore.Domain.Abstract;


namespace SportsStore.WebUI.Controllers
{
    /// <summary>
    /// Class child action
    /// </summary>
    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null) 
        {
            ViewBag.SelectedCategory = category;

            IEnumerable<string> categories = 
                repository.Products.Select(x => x.Category)
                .Distinct().OrderBy(x => x);

            return PartialView(categories);
        }
    }
}
