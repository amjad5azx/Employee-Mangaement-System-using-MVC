using Backend.Models;

namespace Backend.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAll();
        Task<Role> GetById(int id);
        Task Add(Role data);
        void Update(Role data,int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
