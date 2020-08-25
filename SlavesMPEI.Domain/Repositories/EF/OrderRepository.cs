using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SlavesMPEI.Domain.Entities;
using SlavesMPEI.Domain.Repositories.Abstracts;

namespace SlavesMPEI.Domain.Repositories.EF
{
    public class OrderRepository : IOrder
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        
        public async Task AddOrderAsync(Order order)
        {
            await context.Orders.AddAsync(order);
            await context.SaveChangesAsync();
        }
        
        public async Task DeleteOrderAsync(Order order)
        {
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
        }
        
        public async Task<Order> GetOrderByIdAsync(string id)
        {
            return await context.Orders.FirstOrDefaultAsync(order => order.Id == id);
        }
        
        public async Task<IList<Order>> GetOrdersAsync()
        {
            return await context.Orders.ToListAsync();
        }
        
        public async Task<IList<Order>> GetUserOrdersAsync(string username)
        {
            return await context.Orders.Where(order => order.User.UserName == username).ToListAsync();
        }
    }
}