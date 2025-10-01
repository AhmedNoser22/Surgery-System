namespace Surgery_System.Controllers
{
    public class AuthController(IAuthServices _authServices) : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            var result = await _authServices.RegisterAsync(register);
            if (!result)
            {
                ModelState.AddModelError("", "Email already exists");
                return View(register);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var result = await _authServices.LoginAsync(login);
            if (!result)
            {
                ModelState.AddModelError("", "Invalid login attempt");
                return View(login);
            }
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _authServices.Logout();
            return RedirectToAction("Index", "Home");

        }
        public IActionResult ExternalLogin(string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Auth");
            var properties = _authServices.ConfigureExternalAuth(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        public async Task<IActionResult> ExternalLoginCallback()
        {
            var user = await _authServices.ExternalLoginCallback();
            if (user == null)
                return RedirectToAction("Login");

            return RedirectToAction("Index", "Home");
        }
    }
}
