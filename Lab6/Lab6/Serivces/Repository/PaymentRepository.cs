using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Server.Services.Repository
{
    public class PaymentRepository : IRepository<Payment>
    {
        private readonly DiningroomContext _dbContext;
        public PaymentRepository(DiningroomContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool AddInstance(Payment instance)
        {
            _dbContext.Payments.Add(instance);
            return Save();
        }
        public bool DeleteInstance(int id)
        {
            var payment = _dbContext.Payments.First(x => x.Id == id);
            if(payment != null) _dbContext.Payments.Remove(payment);
            return Save();
        }

        public async Task<IEnumerable<Payment>> GetAll()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<Payment> GetByIdAsync(int id)
        {
           return await _dbContext.Payments.FirstAsync(x => x.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInstance(Payment instance)
        {
            var oldPayment = _dbContext.Payments.First(x => x.Id == instance.Id);
            if (oldPayment != null)
            {
                oldPayment.Order = instance.Order;
                oldPayment.OrderId = instance.OrderId;
                oldPayment.PaymentDate = instance.PaymentDate;
                oldPayment.PaymentType = instance.PaymentType;
            }
            return Save();
        }
    }
}
