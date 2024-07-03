using Backend.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class Deletion
    {
        private readonly AppDbContext _context;

        public Deletion(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAllEmployeesByRoleId(int roleId)
        {
            var employees = await _context.Employees.Where(e => e.RoleId == roleId).ToListAsync();
            _context.Employees.RemoveRange(employees);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllRolesByTeamId(int teamId)
        {
            var roles = await _context.Roles.Where(r => r.TeamId == teamId).ToListAsync();
            _context.Roles.RemoveRange(roles);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllTeamsByDepartmentId(int departmentId)
        {

            var teams = await _context.Teams.Where(t => t.DepartmentId == departmentId).ToListAsync();
            _context.Teams.RemoveRange(teams);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAllDepartmentsByOrganizationId(int organizationId)
        {
            var departments = await _context.Departments.Where(d => d.OrganizationId == organizationId).ToListAsync();
            _context.Departments.RemoveRange(departments);
            await _context.SaveChangesAsync();
        }
    }
}
