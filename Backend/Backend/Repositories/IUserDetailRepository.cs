using Backend.Models;

namespace Backend.Repositories
{
    public interface IUserDetailRepository
    {
        Task<IEnumerable<UserDetail>> GetAll();
        Task<UserDetail> GetById(int id);
        Task Add(UserDetail data);
        void Update(UserDetail data,int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
