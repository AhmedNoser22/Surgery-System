namespace Surgery_System.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }
        public IEnumerable<IdentityRole> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
        }
        public async Task<IdentityRole> CreateRoleAsync(IdentityRole role)
        {
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role), "Role cannot be null");
            }
            var result =await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return role;
            }
            else
            {
                throw new Exception($"Role creation failed: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        public async Task<IEnumerable<UserManagerVM>> GetRolesAsync(string id)
        {
            var UserRole = await _roleManager.FindByIdAsync(id);
            if (UserRole == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            var usersInRole = await _userManager.Users.ToListAsync();
            var UserList = new List<UserManagerVM>();
            foreach (var item in usersInRole)
            {
                var UserMap = _mapper.Map<UserManagerVM>(item);
                UserMap.IsSelected = await _userManager.IsInRoleAsync(item, UserRole.Name!);
                UserList.Add(UserMap);
            }
            return UserList;
        }
        public async Task<IdentityResult> AddUserToRoleAsync(List<UserManagerVM> managerVMs, string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                throw new KeyNotFoundException($"Role with ID {id} not found.");
            }
            foreach (var item in managerVMs)
            {
                var UserId = await _userManager.FindByIdAsync(item.Id);
                if (UserId == null)
                {
                    throw new KeyNotFoundException($"User with ID {id} not found.");
                }
                if (item.IsSelected & !(await _userManager.IsInRoleAsync(UserId, role.Name!)))
                {
                    return await _userManager.AddToRoleAsync(UserId, role.Name!);
                }
                else if (!item.IsSelected && await _userManager.IsInRoleAsync(UserId, role.Name!))
                {
                    return await _userManager.RemoveFromRoleAsync(UserId, role.Name!);
                }
            }
            return IdentityResult.Success;
        }
    }
}
