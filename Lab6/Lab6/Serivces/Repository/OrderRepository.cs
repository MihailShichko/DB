using Lab6.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Server.Services.Repository
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly DiningroomContext _dbContext;

        public OrderRepository(DiningroomContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool AddInstance(Order instance)
        {
            _dbContext.Orders.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
          
            var order = _dbContext.Orders.Include(order => order.OrderMenu).First(o => o.Id == id);
            if (order != null)
            {
                var orderMenus = _dbContext.OrderMenus.Where(om => om.Id == order.OrderMenuId);
                _dbContext.OrderMenus.RemoveRange(orderMenus);

                var review = _dbContext.Reviews.FirstOrDefault(r => r.OrderId == order.Id);
                if (review != null)
                {
                    _dbContext.Reviews.Remove(review);
                }

                var payment = _dbContext.Payments.FirstOrDefault(p => p.OrderId == order.Id);
                if (payment != null)
                {
                    _dbContext.Payments.Remove(payment);
                }

                var orderCook = _dbContext.OrderCoocks.FirstOrDefault(oc => oc.Ordernum == order.Id);
                if (orderCook != null)
                {
                    _dbContext.OrderCoocks.Remove(orderCook);
                }

                _dbContext.Orders.Remove(order);
               
            }

            return Save();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _dbContext.Orders.Include(order => order.Client).Include(order => order.OrderMenu.Menu).FirstAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _dbContext.Orders.Include(order => order.Client).Include(order => order.OrderMenu.Menu).ToListAsync();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInstance(Order instance)
        {
            var oldOrder = _dbContext.Orders.First(o => o.Id == instance.Id);
            oldOrder.OrderCoocks = instance.OrderCoocks;
            oldOrder.OrderMenu = instance.OrderMenu;
            oldOrder.OrderMenuId = instance.OrderMenuId;
            oldOrder.Reviews = instance.Reviews;
            oldOrder.Client = instance.Client;
            oldOrder.ClientId = instance.ClientId;
            return Save();
        }
    }
}
