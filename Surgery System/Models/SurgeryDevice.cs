namespace Surgery_System.Models
{
    public class SurgeryDevice
    {
        public int SurgerId { get; set; }
        public int DeviceId { get; set; }
        public Surgery Surgery { get; set; } = default!;
        public MedicalDevice Device { get; set; } = default!;
    }
}
