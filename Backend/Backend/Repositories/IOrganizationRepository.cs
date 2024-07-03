using Backend.Models;

namespace Backend.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAll();
        Task<Organization> GetById(int id);
        Task Add(Organization data);
        void Update(Organization data,int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
