using Etickets_Platform.Data.cart;
using Etickets_Platform.Data.Services;
using Etickets_Platform.Data.Static;
using Etickets_Platform.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Etickets_Platform.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IMoviesService _movieService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;


        public OrdersController(IMoviesService movieService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _movieService=movieService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;

        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId,userRole);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.shoppingCartItems = items;
            var response = new ShoppingCartVm()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };
            return View(response);
        }
        public async Task<RedirectToActionResult> AddItemToShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);
            if(item!=null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
    }

        public async Task<RedirectToActionResult>RemoveItemFromShoppingCart(int id)
        {
            var item = await _movieService.GetMovieByIdAsync(id);
            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); ;
            var userEmailAddress = User.FindFirstValue(ClaimTypes.Email); ;
           await  _ordersService.StoreOrderAsync(items, userId, userEmailAddress);

            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderComplete");

        }
    }

    
}
