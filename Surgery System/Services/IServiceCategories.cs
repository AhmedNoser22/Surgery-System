namespace Surgery_System.Services
{
    public interface IServiceCategories
    {
        IEnumerable<SelectListItem> GetAllCategories();
    }
}
