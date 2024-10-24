using Doctor.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Doctor.Model;
using Doctor.Model.App;
using Microsoft.AspNetCore.Authorization;

namespace Doctor.presentation.WebAPP.Controllers
{
    [Authorize]
   public class ProfileController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(IUserRepository userRepository, ILogger<ProfileController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult EnterUserId()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterUserId(int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
            {
                _logger.LogError($"User with ID {userId} not found.");
                return NotFound();
            }

            return RedirectToAction("EditUser", new { id = userId });
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                _logger.LogError($"User with ID {id} not found.");
                return NotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult EditUser(ApplicationUser updatedUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = _userRepository.GetById(updatedUser.iduser);
        //        if (user == null)
        //        {
        //            _logger.LogError($"User with ID {updatedUser.Id} not found.");
        //            return NotFound();
        //        }

        //        // تحديث بيانات المستخدم
        //        user.UserName = updatedUser.UserName;
        //        user.Email = updatedUser.Email;
        //        user.Role = updatedUser.Role;

        //        _userRepository.Add(user); // استخدام Repository لإضافة البيانات
        //        _logger.LogInformation($"User with ID {updatedUser.Id} has been updated successfully.");

        //        TempData["SuccessMessage"] = "Your profile has been updated successfully!";
        //        return RedirectToAction("EditUser","Profile", new { id = updatedUser.Id });
        //    }

        //    _logger.LogError("Model state is invalid: " + string.Join(", ", ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))));
        //    return View(updatedUser);
        //}

        [HttpGet]
        public IActionResult Profile(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                _logger.LogError($"User with ID {id} not found.");
                return NotFound();
            }

            return View(user);
        }

        
    }
}