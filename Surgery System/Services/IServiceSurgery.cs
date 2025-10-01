namespace Surgery_System.Services
{
    public interface IServiceSurgery
    {
        Task<IEnumerable<Surgery>> GetAllSurgeriesAsync();
        Surgery? GetById(int id);
        Task CreateSurgeryAsync(CreateSurgeryVM model);
        Task<Surgery?> EditSurgeryAsync(EditSurgeryVM model);
        bool DeleteSurgery(int id);
    }
}
