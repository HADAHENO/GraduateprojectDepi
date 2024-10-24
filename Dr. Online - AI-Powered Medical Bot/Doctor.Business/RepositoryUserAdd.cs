using Doctor.Data.APP;
using Doctor.Model.App;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.Business
{
    public class RepositoryUserAdd : IRepositoryUserAdd
    {
        private readonly DoctorContext _context;

        public RepositoryUserAdd(DoctorContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(ApplicationUser user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

       
        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

         public async Task<List<ApplicationUser>> SearchUsersAsync(string searchString)
        {
            var users = from u in _context.Users
                        select u;

            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.UserName.Contains(searchString) || u.Email.Contains(searchString));
            }

            return await users.ToListAsync();
        }

         public async Task<ApplicationUser> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

         public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
