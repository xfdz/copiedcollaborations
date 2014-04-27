﻿using System;
using Moq;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Abstract;

using SportsStore.WebUI.Models;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CanCreateCategoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange - crate mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                    new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                    new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                    new Product {ProductID = 4, Name = "P4", Category = "Oranges"},
                }.AsQueryable()
            );

            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            // Act - get the set of categories
            string[] results = ((IEnumerable<string>)target.Menu().Model).ToArray();
            
            // Assert
            Assert.AreEqual(results.Length, 3);
            Assert.AreEqual(results[0], "Apples");
            Assert.AreEqual(results[1], "Oranges");
            Assert.AreEqual(results[2], "Plums");
        }
    }
}
