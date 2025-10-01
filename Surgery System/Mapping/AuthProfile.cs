namespace Surgery_System.Mapping
{
    public class AuthProfile:Profile
    {
        public AuthProfile()
        {
            CreateMap<RegisterVM, AppUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));
            CreateMap<AppUser, UserVM>();
            CreateMap<IdentityRole, RoleVM>();
            CreateMap<AddRoleVM, IdentityRole>();
            CreateMap<AppUser, UserManagerVM>()
                .ReverseMap();
        }
    }
}
