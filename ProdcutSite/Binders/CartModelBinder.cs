using System;
using System.Web.Mvc;
using ProductSite.Domain.Entities;

namespace ProdcutSite.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext,ModelBindingContext bindingContext)
        {
            // get the Cart from the session             
            if (controllerContext.HttpContext.Session != null)
            {
                Cart cart = (Cart) controllerContext.HttpContext.Session[sessionKey];
                // create the Cart if there wasn't one in the session data          
                if (cart == null)
                {
                    cart = new Cart();
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
                // return the cart      
                return cart;
            }
            else
            {
                return null;
            }
        }
    }

}