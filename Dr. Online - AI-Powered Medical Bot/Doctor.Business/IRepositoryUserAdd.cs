using Doctor.Model;
using Doctor.Model.App;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Doctor.Business
{
    public interface IRepositoryUserAdd
    {
        Task<ApplicationUser> GetUserByIdAsync(int id);
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<List<ApplicationUser>> SearchUsersAsync(string searchString);
        Task AddUserAsync(ApplicationUser user);
        Task DeleteUserAsync(int id);
    }
}
