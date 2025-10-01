namespace Surgery_System.Data.Entity_Type_Configuration
{
    public class SurgeryCategoryConfiguration : IEntityTypeConfiguration<SurgeryCategory>
    {
        public void Configure(EntityTypeBuilder<SurgeryCategory> builder)
        {
            builder.ToTable("SurgeryCategories");
            builder.HasKey(sc => sc.Id);
            builder.Property(sc => sc.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(sc => sc.Description)
                .HasMaxLength(1000);
            builder.HasMany(sc => sc.Surgeries)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new SurgeryCategory { Id = 1, Name = "Cardiac Surgery", Description = "Heart and blood vessel surgeries." },
                new SurgeryCategory { Id = 2, Name = "Neurosurgery", Description = "Brain and nervous system surgeries." },
                new SurgeryCategory { Id = 3, Name = "Orthopedic Surgery", Description = "Bones, joints, and muscles surgeries." },
                new SurgeryCategory { Id = 4, Name = "General Surgery", Description = "Abdomen and digestive system surgeries." }
            );
        }
    }
}
