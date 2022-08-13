using FinalProject.DataFolder;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Controllers
{
    public class FacultyController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Data _dataFolder;

        public FacultyController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, Data dataFolder)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dataFolder = dataFolder;
        }
        public async Task<IActionResult> StudentList()
        {
            var users = await _userManager.GetUsersInRoleAsync("Student");
            return View(users);

        }

        public IActionResult Knowledge()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Knowledge(Knowledges knowledge)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataFolder.Knowledges.Add(knowledge);
                    _dataFolder.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception)
            {
                return View("Somthing went to Wrong please try again");
            }           
        }
        public async Task<IActionResult> ShowArtical()
        {
            var result = await _dataFolder.Knowledges.ToListAsync();
            return View(result);
        }
        public async Task<IActionResult> AllArtical(int Id)
        {
            var article = await _dataFolder.Knowledges.FindAsync(Id);

            return View(article);
        }
        public IActionResult Chat()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Chat(ChatModel chatModel)
        {
            if (ModelState.IsValid)
            {
                if (chatModel.sender != chatModel.receiver)
                {
                    TempData["AlertMessage"] = "Massege Send Successfully";
                    var result = _dataFolder.ChatModels.AddAsync(chatModel);
                    _dataFolder.SaveChangesAsync();
                    return RedirectToAction("Chat");
                }               
            }
            ModelState.AddModelError("", "Reciver And Sender UserName Same");
            return View();           
        }
        
        public IActionResult Tosender(int id)
        {
            var Send =  _dataFolder.ChatModels.Where(x => x.Id == id).ToList();
            if (Send != null)
            {
                var response = from result in _dataFolder.ChatModels
                             where result.receiver == User.Identity.Name
                             select result;
                return View(response);
            }
            return View();

        }
        public IActionResult Notification()
        {
            return View();
        }
    }
}
