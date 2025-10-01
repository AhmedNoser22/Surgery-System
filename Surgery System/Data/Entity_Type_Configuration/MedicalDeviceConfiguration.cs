namespace Surgery_System.Data.Entity_Type_Configuration
{
    public class MedicalDeviceConfiguration : IEntityTypeConfiguration<MedicalDevice>
    {
        public void Configure(EntityTypeBuilder<MedicalDevice> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(1000);
            builder.Property(s => s.SerialNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder.HasData(
                new MedicalDevice
                {
                    Id = 1,
                    Name = "Anesthesia Machine",
                    Description = "Provides anesthesia to patients.",
                    SerialNumber = "AN-2025-001",
                },
                new MedicalDevice
                {
                    Id = 2,
                    Name = "Surgical Table",
                    Description = "Adjustable table for operations.",
                    SerialNumber = "ST-2025-002"
                },
                new MedicalDevice
                {
                    Id = 3,
                    Name = "Heart-Lung Machine",
                    Description = "Supports heart and lung functions.",
                    SerialNumber = "HL-2025-003",
                },
                new MedicalDevice
                {
                    Id = 4,
                    Name = "MRI Scanner",
                    Description = "Magnetic resonance imaging device.",
                    SerialNumber = "MRI-2025-004"
                },
                new MedicalDevice
                {
                    Id = 5,
                    Name = "Orthopedic Drill",
                    Description = "For bone surgeries.",
                    SerialNumber = "OD-2025-005"
                },
                new MedicalDevice
                {
                    Id = 6,
                    Name = "Endoscope",
                    Description = "For internal organ viewing.",
                    SerialNumber = "EN-2025-006",
                },
                new MedicalDevice
                {
                    Id = 7,
                    Name = "Defibrillator",
                    Description = "Restarts or stabilizes heart rhythm.",
                    SerialNumber = "DF-2025-007"
                }
            );



        }
    }
}
