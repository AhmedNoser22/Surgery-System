namespace Surgery_System.Controllers
{
    public class UserController(UserManager<AppUser> user,IMapper mapper) : Controller
    {
        public IActionResult Index()
        { 
            var users = user.Users.ToList();
            var uservm = mapper.Map<List<UserVM>>(users);
            return View(uservm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var userVM = await user.FindByIdAsync(id);
            if (userVM == null)
            {
                return NotFound();
            }
            var uservm = mapper.Map<UserVM>(userVM);
            return View(uservm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var userVM = await user.FindByIdAsync(id);
            if (userVM == null)
            {
                return NotFound();
            }
            var result = await user.DeleteAsync(userVM);
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            var uservm = mapper.Map<UserVM>(userVM);
            return View(uservm);
        }
    }
}
