namespace Surgery_System.Data
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<MedicalDevice> MedicalDevices { get; set; }
        public DbSet<SurgeryCategory> SurgeryCategories {  get; set; }
        public DbSet<SurgeryDevice> SurgeryDevices {  get; set; }

    }
}
