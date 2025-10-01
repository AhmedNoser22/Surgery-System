namespace Surgery_System.Services
{
    public interface IServiceDevices
    {
       IEnumerable<SelectListItem> GetAllDevices();
    }
}
