using Microsoft.AspNetCore.Authentication;
namespace Surgery_System.Services
{
    public interface IAuthServices
    {
        Task<bool> RegisterAsync(RegisterVM register);
        Task<bool> LoginAsync(LoginVM login);
        Task<bool> Logout();
        AuthenticationProperties ConfigureExternalAuth(string provider, string redirectUrl);
        Task<AppUser?> ExternalLoginCallback();

    }
}
