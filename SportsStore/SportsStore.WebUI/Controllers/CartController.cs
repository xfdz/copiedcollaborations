using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {   
        public CartController(IProductRepository repo, IOrderProcessor procs)
        {
            repository = repo;
            orderProcessor = procs;
        }

        /// <summary>
        /// Will be invoked for a POST request—in this case, when the user submits the form.
        /// </summary>
        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        /// <summary>
        /// This has the effect of sending an HTTP redirect instruction to the client browser, asking the browser 
        /// to request a new URL. In this case, we have asked the browser to request a URL that will call the Index
        /// action method of the Cart controller.
        /// </summary>
        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
               .FirstOrDefault(p => p.ProductID == productId);

            if(product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl });   
        }

        /// <summary>
        /// This has the effect of sending an HTTP redirect instruction to the client browser, asking the browser 
        /// to request a new URL. In this case, we have asked the browser to request a URL that will call the Index
        /// action method of the Cart controller.
        /// </summary>
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if(product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new{ returnUrl });
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View( new CartIndexViewModel{ Cart = cart, ReturnUrl = returnUrl } );
        }

        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }
       
        #region Fields

        private IOrderProcessor orderProcessor;
        private IProductRepository repository;
        
        #endregion

    }
}
