namespace Surgery_System
{
    public static class DependencyInjectionServices
    {
        public static IServiceCollection AddSurgerySystemServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<AppUser, IdentityRole>
                (
                options=>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.User.RequireUniqueEmail = true;
                }
                ).AddEntityFrameworkStores<AppDbContext>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
            })
                .AddCookie()
                .AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                });

            services.AddScoped<IServiceCategories, ServiceCategories>();
            services.AddScoped<IServiceDevices, ServiceDevices>();
            services.AddScoped<IServiceSurgery, ServiceSurgery>();
            services.AddAutoMapper(typeof(MapProfile));
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddScoped<IRoleService, RoleService>();
            return services;
        }
    }
}
