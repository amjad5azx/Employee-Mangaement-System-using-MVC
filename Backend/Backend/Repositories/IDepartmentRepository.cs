using Backend.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetById(int id);
        Task Add(Department data);
        void Update(Department data, int id);
        void Remove(int id);
        Task SaveChanges();
    }
}
