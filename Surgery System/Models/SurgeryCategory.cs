namespace Surgery_System.Models
{
    public class SurgeryCategory : BaseEntity
    {
        public ICollection<Surgery> Surgeries { get; set; } = new List<Surgery>();
    }
}
