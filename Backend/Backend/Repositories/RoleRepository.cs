using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetById(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task Add(Role role)
        {
            await _context.Roles.AddAsync(role);
        }

        public void Update(Role role, int id)
        {
            var existingRole = _context.Roles.Find(id);
            if (existingRole != null)
            {
                existingRole.Name = role.Name;
                existingRole.TeamId = role.TeamId;
                _context.Roles.Update(existingRole);
            }
        }

        public void Remove(int id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
