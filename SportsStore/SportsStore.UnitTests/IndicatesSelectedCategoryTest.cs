using System;
using Moq;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.CSharp.RuntimeBinder;

using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Abstract;

using SportsStore.WebUI.Models;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class IndicatesSelectedCategoryTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange- create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(
                new Product[] 
                {  new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                   new Product {ProductID = 4, Name = "P2", Category = "Oranges"},
                }.AsQueryable()
            );

            // Arrange - create the controller
            NavController target = new NavController(mock.Object);

            // Arrange - define the category to selected
            string categoryToSelect = "Apples";

            // Action
            string result = target.Menu(categoryToSelect).ViewBag.SelectedCategory;

            // Assert
            Assert.AreEqual(categoryToSelect, result);
        }
    }
}
