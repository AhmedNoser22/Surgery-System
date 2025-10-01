namespace Surgery_System.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var roles = _roleService.GetRoles();
            var roleViewModels = _mapper.Map<IEnumerable<RoleVM>>(roles);
            return View(roleViewModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddRoleVM roleVM)
        {
            if (!ModelState.IsValid)
            {
                return View(roleVM);
            }
            var existingRole = _roleService.GetRoles().FirstOrDefault(r => r.Name == roleVM.Name);
            if (existingRole != null)
            {
                ModelState.AddModelError("", "Role already exists");
                return View(roleVM);
            }
            var role = _mapper.Map<IdentityRole>(roleVM);
            if (role == null)
            {
                ModelState.AddModelError("", "Role cannot be null");
                return View(roleVM);
            }
            var createdRole = await _roleService.CreateRoleAsync(role);
            if (createdRole == null)
            {
                ModelState.AddModelError("", "Role creation failed");
                return View(roleVM);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UsersInRole(string id)
        {
            var role = await _roleService.GetRolesAsync(id);
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UsersInRole(List<UserManagerVM> managerVMs, string id)
        {
            if (!ModelState.IsValid)
            {
                return View(managerVMs);
            }
            var result = await _roleService.AddUserToRoleAsync(managerVMs, id);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Failed to add users to role");
                return View(managerVMs);
            }
            return RedirectToAction("Index");
        }
    }
}
