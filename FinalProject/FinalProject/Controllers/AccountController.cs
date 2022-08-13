using FinalProject.AccountRepositroy;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.RegisterAsync(register);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Register Successfully";
                    return RedirectToAction("Login");
                }
                ModelState.AddModelError("", "Email Id Already Exists");
                
            }
            ModelState.AddModelError("", "Somethin went to wrong please try again");
            return View();  
        }

        public IActionResult Login()
        {
            return View();
        }        
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    var result = await _accountRepository.LoginAsync(login);
                    if (result.Succeeded)
                    {
                        TempData["AlertMessage"] = "Login Successfully";
                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "Your Account is Locked Please try after 15 minutes");
                    }
                    ModelState.AddModelError("", "Invalid Email and Password");
                }
                return View();
            }
            catch (Exception)
            {
                return View("Please Try Again");
            }          
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {         
            await _accountRepository.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }              
        public ActionResult Index()
        {
            return View();
        }
    }
}
