using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaglarDurmus.ShoppingApi.Entities.Concrete;
using CaglarDurmus.ShoppingApi.MvcWebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace CaglarDurmus.ShoppingApi.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Cart GetCart()
        {
            Cart cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            if (cartToCheck == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheck = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }

            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
