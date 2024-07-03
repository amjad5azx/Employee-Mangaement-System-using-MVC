using Backend.Models;

namespace Backend.Repositories
{
    public interface ITeamRepository
    {
        Task<IEnumerable<Team>> GetAll();
        Task<Team> GetById(int id);
        Task Add(Team data);
        void Update(Team data,int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
