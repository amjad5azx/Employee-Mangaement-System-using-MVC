using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Add(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public void Update(Employee employee, int id)
        {
            var p_employee = _context.Employees.Find(id);
            if (p_employee != null)
            {
                p_employee.EmployeeName = employee.EmployeeName;
                p_employee.RoleId = employee.RoleId;
                p_employee.TeamId = employee.TeamId;
                _context.Employees.Update(p_employee);
            }
        }

        public void Remove(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
