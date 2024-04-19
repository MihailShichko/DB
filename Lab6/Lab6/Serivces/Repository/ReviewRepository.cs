using Lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab6.Server.Services.Repository
{
    public class ReviewRepository : IRepository<Review>
    {
        private readonly DiningroomContext _dbContext;
        public ReviewRepository(DiningroomContext context)
        {
            _dbContext = context;
        }
        public bool AddInstance(Review instance)
        {
            _dbContext.Reviews.Add(instance);
            return Save();
        }

        public bool DeleteInstance(int id)
        {
            var review = _dbContext.Reviews.First(r => r.Id == id);
            if(review != null) _dbContext.Reviews.Remove(review);

            return Save();
        }

        public async Task<IEnumerable<Review>> GetAll()
        {
            return await _dbContext.Reviews.Include(review => review.Order).ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _dbContext.Reviews.Include(review => review.Order).FirstAsync(r => r.Id == id);
        }

        public bool Save()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateInstance(Review instance)
        {
            var oldReview = _dbContext.Reviews.First(r => r.Id == instance.Id);
            if (oldReview != null)
            {
                oldReview.Order = instance.Order;
                oldReview.OrderId = instance.OrderId;
                oldReview.Rating = instance.Rating;
                oldReview.Id = instance.Id;
            }
            return Save();
        }
    }
}
