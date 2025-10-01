namespace Surgery_System.Data.Entity_Type_Configuration
{
    public class SurgeryDeviceConfiguration : IEntityTypeConfiguration<SurgeryDevice>
    {
        public void Configure(EntityTypeBuilder<SurgeryDevice> builder)
        {
            builder.HasKey(s => new {s.SurgerId,s.DeviceId})
                .HasName("PK_SurgeryDevice");
            builder.ToTable("SurgeryDevice");
        }
    }
}
