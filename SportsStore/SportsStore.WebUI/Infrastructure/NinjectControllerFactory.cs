using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Collections.Generic;
using System.Configuration;

using Moq;
using Ninject;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory 
    {
        public NinjectControllerFactory() 
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)            
        {
            return ( controllerType != null ) ? (IController)ninjectKernel.Get(controllerType) : null;
        }

        private void AddBindings() 
        {// put additional bindings here

            // Mock implementation of the IProductRepository Interface
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();

            //mock.Setup(m => m.Products).Returns( 
            //    new List<Product> 
            //    {
            //        new Product { Name = "Football", Price = 25 },
            //        new Product { Name = "Surf board", Price = 179 },
            //        new Product { Name = "Running shoes", Price = 95 }
            //    }
            //    .AsQueryable()
            //);
            //ninjectKernel.Bind<IProductRepository>().ToConstant(mock.Object);

            ninjectKernel.Bind<IProductRepository>().To<EFProductRepository>();

            bool writeAsFile = Boolean.Parse( ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? Boolean.FalseString );
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = writeAsFile             
            };

            ninjectKernel
             .Bind<IOrderProcessor>()
             .To<EmailOrderProcessor>()
             .WithConstructorArgument("settings", emailSettings);

        }

        private IKernel ninjectKernel;

    }
}