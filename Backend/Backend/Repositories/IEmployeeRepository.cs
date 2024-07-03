using Backend.Models;

namespace Backend.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(Employee data);
        void Update(Employee data,int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
