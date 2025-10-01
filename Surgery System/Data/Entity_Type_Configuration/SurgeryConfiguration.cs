namespace Surgery_System.Data.Entity_Type_Configuration
{
    public class SurgeryConfiguration : IEntityTypeConfiguration<Surgery>
    {
        public void Configure(EntityTypeBuilder<Surgery> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(s=>s.ImageUrl)
                .IsRequired()
                .HasMaxLength(200);
            builder.HasOne(s => s.Category)
                .WithMany(c => c.Surgeries)
                .HasForeignKey(s => s.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(s => s.SurgeryDevices)
                .WithOne(sd => sd.Surgery)
                .HasForeignKey(sd => sd.SurgerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
