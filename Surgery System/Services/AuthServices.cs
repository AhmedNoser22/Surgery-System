using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace Surgery_System.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthServices(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<bool> RegisterAsync(RegisterVM register)
        {
            var existingEmail = await _userManager.FindByEmailAsync(register.Email);
            if (existingEmail != null)
            {
                return false;
            }
            var RegisterUser = _mapper.Map<AppUser>(register);
            var result = await _userManager.CreateAsync(RegisterUser, register.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(RegisterUser, isPersistent: false);
                await _userManager.AddToRoleAsync(RegisterUser, "User");
                return true;
            }
            return false;
        }
        public async Task<bool> LoginAsync(LoginVM login)
        {
            var user =await _userManager.FindByEmailAsync(login.Email);
            if (user == null)
            {
                return false;
            }
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, login.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }
        public async Task<bool> Logout()
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        public AuthenticationProperties ConfigureExternalAuth(string provider, string redirectUrl)
        {
            return _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        }
        public async Task<AppUser?> ExternalLoginCallback()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return null;

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
            if (signInResult.Succeeded)
            {
                return await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
            }
            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new AppUser { UserName = email, Email = email };
                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "User");
            }

            await _userManager.AddLoginAsync(user, info);
            await _signInManager.SignInAsync(user, false);

            return user;
        }
    }
}
