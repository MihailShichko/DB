using Lab6.Models;
using Microsoft.EntityFrameworkCore;


namespace Lab6.Server.Services.Repository
{
    public class MenuRepository: IRepository<Menu>
    {
        private DiningroomContext _dbContext;
        public MenuRepository(DiningroomContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddInstance(Menu instance)
        {
            _dbContext.Menus.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var menu = _dbContext.Menus.First(menuItem => menuItem.Id == id);
            if(menu != null) 
            {
                //var query = from orderMenu in _dbContext.OrderMenus
                //            join order in _dbContext.Orders on orderMenu.Id equals order.OrderMenuId
                //            join payment in _dbContext.Payments on order.Id equals payment.OrderId
                //            join review in _dbContext.Reviews on order.Id equals review.OrderId
                //            join orderCoock in _dbContext.OrderCoocks on order.Id equals orderCoock.Ordernum
                //            where orderMenu.MenuId == id
                //            select new
                //            {
                //                OrderMenu = orderMenu,
                //                Order = order,
                //                Payment = payment,
                //                Review = review,
                //                OrderCoock = orderCoock
                //            };

                //var results = query.ToList();

                //foreach (var result in results)
                //{
                //    _dbContext.OrderMenus.Remove(result.OrderMenu);
                //    _dbContext.Orders.Remove(result.Order);
                //    _dbContext.Payments.Remove(result.Payment);
                //    _dbContext.Reviews.Remove(result.Review);
                //    _dbContext.OrderCoocks.Remove(result.OrderCoock);
                //}

                _dbContext.Menus.Remove(menu);

            }
            return Save();
        }

        public async Task<IEnumerable<Menu>> GetAll()
        {
            return await _dbContext.Menus.ToListAsync();
        }

        public async Task<Menu> GetByIdAsync(int id)
        {
            return await _dbContext.Menus.FirstAsync(menuitem =>  menuitem.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInstance(Menu instance)
        {
            var oldMenuItem = _dbContext.Menus.First(menuItem => menuItem.Id == instance.Id);
            if (oldMenuItem != null)
            {
                oldMenuItem.OrderMenus = instance.OrderMenus;
                oldMenuItem.Price = instance.Price;
                oldMenuItem.Name = instance.Name;
                oldMenuItem.Compaund = instance.Compaund;
            }

            return Save();
        }
    }
}
