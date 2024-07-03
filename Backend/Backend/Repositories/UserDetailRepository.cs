using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly AppDbContext _context;

        public UserDetailRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDetail>> GetAll()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> GetById(int id)
        {
            return await _context.UserDetails.FindAsync(id);
        }

        public async Task Add(UserDetail data)
        {
            await _context.UserDetails.AddAsync(data);
        }

        public void Update(UserDetail data, int id)
        {
            var existingUserDetail = _context.UserDetails.Find(id);
            if (existingUserDetail != null)
            {
                existingUserDetail.Firstname = data.Firstname;
                existingUserDetail.Lastname = data.Lastname;
                existingUserDetail.Username = data.Username;
                existingUserDetail.Password = data.Password;
                _context.UserDetails.Update(existingUserDetail);
            }
        }


        public void Remove(int id)
        {
            var userDetail = _context.UserDetails.Find(id);
            if (userDetail != null)
            {
                _context.UserDetails.Remove(userDetail);
            }
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
