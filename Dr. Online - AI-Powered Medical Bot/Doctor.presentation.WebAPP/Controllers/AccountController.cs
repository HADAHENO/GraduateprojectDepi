 
using Doctor.Model.App;
using Doctor.presentation.WebAPP.Helper;
using Doctor.presentation.WebAPP.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Doctor.presentation.WebAPP.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> _userManager { get; set; }
        public SignInManager<ApplicationUser> _signIn { get; set; }
        public IHttpContextAccessor _httpContextAccessor { get; set; }
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signIn, IHttpContextAccessor httpContextAccessor)
        {
            this._userManager = userManager;
            this._signIn = signIn;
            this._httpContextAccessor = httpContextAccessor;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser User = new ApplicationUser();
                User.UserName = model.UserName;
                User.PasswordHash = model.Password;
                User.Email = model.Email;
                User.Gender = model.Gender;

                User.BirthDate = model.BirthDate;
                IdentityResult result = await _userManager.CreateAsync(User, model.Password);
                if (result.Succeeded)
                {
                    await _signIn.SignInAsync(User, false);
                    return RedirectToAction("Index", "Home");

                }
     

            }
            return View("Register", model);
        }
        #endregion
        #region Login
        [HttpGet]
        public IActionResult login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> savelogin(loginVM model)

        {
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(model.username);
                if (user != null)
                {
                    bool Identifier = await _userManager.CheckPasswordAsync(user, model.password);
                    if (Identifier)
                    {
                        await _signIn.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "password faild or username");
            }

            return View("login", model);
        }
        #endregion
        #region Logout
        public async Task<IActionResult> logout()
        {
            await _signIn.SignOutAsync();

            return RedirectToAction("login");
        }
        #endregion
        #region ForgetPassword
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {

                ApplicationUser user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new { email = user.Email, token = token }, "https", _httpContextAccessor.HttpContext.Request.Host.ToString());
                    Email email = new Email()
                    {
                        To = user.Email,
                        From = "hagersayed573@gmail.com",
                        Title = "Reset Password",
                        Body = url
                    };
                    EmaillSetting.SendEmail(email);
                    return View("CheckEmail");
                }
            }
            ModelState.AddModelError(" ", "Email not exist");
            return View("ForgetPassword", model);
        }

        #endregion
        #region reset_password
        [HttpGet]
        public IActionResult ResetPassword([FromQuery] String email, [FromQuery] string token)
        {
            ResetPasswordVM reset = new ResetPasswordVM();
            TempData["email"] = email;
            TempData["token"] = token;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
        {
            string email = TempData["email"] as string;
            string token = TempData["token"] as string;
            if (ModelState.IsValid)
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(email);
                if (user is not null)
                {
                    IdentityResult result = await _userManager.ResetPasswordAsync(user, token, model.Password);
                    if (result.Succeeded)
                    {
                        return View("SuccessdResetPassword");
                    }


                }
                return View("login");
            }


            return View();
        }

        #endregion

    }
}
