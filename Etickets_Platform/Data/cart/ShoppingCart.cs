using Etickets_Platform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//This is a class which we are going to use for add data to shoppong cart and remove data from shopping cart.

namespace Etickets_Platform.Data.cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string shoppingCartId { get; set; }

        public List<ShoppingCartItem> shoppingCartItems { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();
            session.SetString("cartId", cartId);

            return new ShoppingCart(context) { shoppingCartId = cartId };
        }

        public void AddItemToCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.movie.id == movie.id
              && n.ShoppingCartId == shoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = shoppingCartId,
                    movie = movie,
                    Amount = 1,
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
                _context.SaveChanges();
               
            
        }

        public void RemoveItemFromCart(Movie movie)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.movie.id == movie.id &&
              n.ShoppingCartId == shoppingCartId);
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount>1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem>GetShoppingCartItems()
        {
            return shoppingCartItems ?? (shoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId)
                                          .Include(n => n.movie).ToList());



        }

        public double GetShoppingCartTotal()=> _context.ShoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId)
                .Select(n => n.movie.Price * n.Amount).Sum();

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == shoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
           await _context.SaveChangesAsync();

        }

    }


}
