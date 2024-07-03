using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _context;
        public TeamRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Team data)
        {
            await _context.Teams.AddAsync(data);
        }

        public async Task<IEnumerable<Team>> GetAll()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team> GetById(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public void Remove(int id)
        {
            var team=_context.Teams.Find(id);
            if(team != null)
            {
                _context.Teams.Remove(team);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Team data,int id)
        {
            var team = _context.Teams.Find(id);
            if (team != null)
            {
                _context.Teams.Update(data);
            }
        }
    }
}
