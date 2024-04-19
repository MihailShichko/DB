using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Server.Services.Repository
{
    public class CoockRepository : IRepository<Coock>
    {
        private readonly DiningroomContext _dbContext;

        public CoockRepository( DiningroomContext dbContext )
        {
            _dbContext = dbContext;
        }

        public bool AddInstance(Coock instance)
        {
            _dbContext.Coocks.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var coock = _dbContext.Coocks.First(c => c.Id == id);
            if(coock != null) _dbContext.Coocks.Remove(coock);
            return Save();
        }

        public async Task<Coock> GetByIdAsync(int id)
        {
            return await _dbContext.Coocks.FirstAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Coock>> GetAll()
        {
            return await _dbContext.Coocks.ToListAsync();
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;     
        }

        public bool UpdateInstance(Coock instance)
        {
            var oldCoock = _dbContext.Coocks.First(c => c.Id == instance.Id);
            if (oldCoock != null)
            {
                oldCoock.OrderCoocks = instance.OrderCoocks;
                oldCoock.Post = instance.Post;
                oldCoock.Payment = instance.Payment;
                oldCoock.Name = instance.Name;
                oldCoock.Telephonenumber = instance.Telephonenumber;
            }

            return Save();
        }
    }
}
