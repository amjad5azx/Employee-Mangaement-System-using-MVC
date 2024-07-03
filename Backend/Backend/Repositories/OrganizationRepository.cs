using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Repositories
{
    public class OrganizationRepository:IOrganizationRepository
    {
        private readonly AppDbContext _context;
        public OrganizationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Organization>> GetAll()
        {
            return await _context.Organizations.ToListAsync();
        }
        public async Task<Organization> GetById(int id)
        {
            return await _context.Organizations.FindAsync(id);
        }
        public async Task Add(Organization data)
        {
            await _context.Organizations.AddAsync(data);
        }
        public void Update(Organization data, int id)
        {
            var existingOrganization = _context.Organizations.Find(id);
            if (existingOrganization != null)
            {
                existingOrganization.Name = data.Name;
                _context.Organizations.Update(existingOrganization);
            }
        }

        public void Remove(int id)
        {
            var organization = _context.Organizations.Find(id);
            if(organization != null)
            {
                _context.Organizations.Remove(organization);
            }
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
