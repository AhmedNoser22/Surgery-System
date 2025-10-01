namespace Surgery_System.Services
{
    public class ServiceCategories : IServiceCategories
    {
        private readonly AppDbContext _context;
        public ServiceCategories(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetAllCategories()
        {
            var result = _context.SurgeryCategories.Select
                (
                x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }
                ).AsNoTracking().ToList();
            return result;
        }
    }
}
