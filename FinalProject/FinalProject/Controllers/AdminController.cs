using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        //private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            //_roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<IActionResult> ListUser()
        {
            var users = await _userManager.GetUsersInRoleAsync("Faculty");
            return View(users);
        }
        public async Task<IActionResult> StudentList()
        {
            var users = await _userManager.GetUsersInRoleAsync("Student");
            return View(users);
        }
        
        
        public IActionResult Delete()
        {
            return View();
        }
        //[Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = "Delete Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Invalid");
                }
                
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", _userManager.Users);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
