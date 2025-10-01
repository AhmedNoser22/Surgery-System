namespace Surgery_System.Services
{
    public class ServiceDevices : IServiceDevices
    {
        private readonly AppDbContext _context;

        public ServiceDevices(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllDevices()
        {
            return _context.MedicalDevices.Select
                (
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }
                ).AsNoTracking().ToList();
        }
    }
}
