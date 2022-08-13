using FinalProject.Models;

using Microsoft.AspNetCore.Identity;

namespace FinalProject.AccountRepositroy
{
    public class AccountRepository:IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }
        public async Task<IdentityResult> RegisterAsync(Register register)
        {
            var user = new ApplicationUser()
            {
                FirstName = register.firstName,
                LastName = register.lastName,
                Email = register.email,
                UserName = register.email
            };
            var result = await _userManager.CreateAsync(user, register.password);
            await _userManager.AddToRoleAsync(user, register.rollTypes.ToString());
            return result;
        }
        public async Task<SignInResult> LoginAsync(Login login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.email, login.password, login.RememberMe, true);
            return result;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        
    }
}
