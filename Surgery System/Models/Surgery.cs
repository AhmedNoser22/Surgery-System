namespace Surgery_System.Models
{
    public class Surgery : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public SurgeryCategory Category { get; set; } = default!;
        public ICollection<SurgeryDevice> SurgeryDevices { get; set; } =default!;
    }
}
