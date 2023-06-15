using Etickets_Platform.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etickets_Platform.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public  async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId,string userRole)
        {
            var orders =await _context.Orders.Include(n => n.orderItems)
                .ThenInclude(n => n.movie).Include(n=>n.User).ToListAsync();
            if(userRole!="Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    Price=item.movie.Price,
                    MovieId=item.movie.id,
                    OrderId=order.id


                };
               await _context.OrderItems.AddAsync(orderitem);

            }

            await _context.SaveChangesAsync();
        }
    }
}
