using System.Configuration;
using Ninject;
using System.Web.Mvc;
using System.Web.Routing;
using System;
using ProductSite.Domain.Abstract;
using ProductSite.Domain.Concrete;
using System.Data.Entity;

namespace ProdcutSite.Controllers
{
    public class NinjectControllerFactory :DefaultControllerFactory 
    {
        private IKernel ninjactKernel;

        public NinjectControllerFactory()
        {
             ninjactKernel = new StandardKernel();  
             AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjactKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            //Implement Here
            ninjactKernel.Bind<IProductsRepository>().To<EFProductRepository>(); 
           // Mock implementation of the IProductRepository Interface 

            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>(   );
            //    mock.Setup(m => m.Products).Returns(new List<Product> {
            //      new Product { Name = "Football", Price = 25 },
            //        new Product { Name = "Surf board", Price = 179 },       
            //        new Product { Name = "Running shoes", Price = 95 }
            //    }.AsQueryable());
            //    ninjactKernel.Bind<IProductsRepository>().ToConstant(mock.Object);

            EmailSettings emailSettings = new EmailSettings 
            { WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false") };
            ninjactKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings); 
        }
    }
}