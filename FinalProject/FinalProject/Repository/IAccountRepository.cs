using FinalProject.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.AccountRepositroy
{
    public interface IAccountRepository
    {
        Task<IdentityResult> RegisterAsync(Register register);
        Task<SignInResult> LoginAsync(Login login);
        Task LogoutAsync();
    }
}
