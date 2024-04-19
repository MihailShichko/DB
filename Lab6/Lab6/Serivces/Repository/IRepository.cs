
namespace Lab6.Server.Services.Repository
{
    public interface IRepository<T>
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetByIdAsync(int id);
        public bool AddInstance(T instance);
        public bool UpdateInstance(T instance);
        public bool DeleteInstance(int id);
        public bool Save();
    }
}
