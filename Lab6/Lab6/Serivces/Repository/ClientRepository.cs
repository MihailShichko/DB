using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Server.Services.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly DiningroomContext _dbContext;

        public ClientRepository(DiningroomContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public bool AddInstance(Client instance)
        {
            _dbContext.Clients.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var client = _dbContext.Clients.First(c => c.Id == id);
            if(client != null) _dbContext.Clients.Remove(client);

            return Save(); 
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _dbContext.Clients.FirstAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInstance(Client instance)
        {
            var oldClient = _dbContext.Clients.First(c => c.Id == instance.Id);
            if (oldClient != null)
            {
                oldClient.Telephonenumber = instance.Telephonenumber;
                oldClient.Fullname = instance.Fullname;
                oldClient.Orders = instance.Orders;
            }

            return Save();
        }
    }
}
