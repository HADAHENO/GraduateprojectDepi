using Microsoft.AspNetCore.Identity;
using Doctor.Business;
using Doctor.Model.App;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Doc.Controllers
{
    public class UsersController : Controller
    {
        private readonly IRepositoryUserAdd _repositoryUser;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;  
        public UsersController(IRepositoryUserAdd repositoryUser, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _repositoryUser = repositoryUser;
            _passwordHasher = passwordHasher;
        }

        // GET: Create User Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Add User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
             
                user.PasswordHash = _passwordHasher.HashPassword(user, user.PasswordHash);

                await _repositoryUser.AddUserAsync(user);
                return RedirectToAction("Index");  
            }
            return View(user);
        }

         public async Task<IActionResult> Index(string searchString)
        {
            var users = await _repositoryUser.SearchUsersAsync(searchString);
            ViewData["CurrentFilter"] = searchString;  
            return View(users);
        }

      
        [HttpGet]
        public async Task<IActionResult> UserProfile(int id)
        {
            var user = await _repositoryUser.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return View(user);
        }

         [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repositoryUser.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
