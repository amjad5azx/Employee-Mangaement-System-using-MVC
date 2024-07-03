using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await _context.Departments.FindAsync(id);
        }

        public async Task Add(Department department)
        {
            await _context.Departments.AddAsync(department);
        }

        public void Update(Department department, int id)
        {
            var existingDepartment = _context.Departments.Find(id);
            if (existingDepartment != null)
            {
                existingDepartment.Name = department.Name;
                _context.Departments.Update(existingDepartment);
            }
        }


        public void Remove(int id)
        {
            var department = _context.Departments.Find(id);
            if (department != null)
            {
                _context.Departments.Remove(department);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
