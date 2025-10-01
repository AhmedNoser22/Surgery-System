namespace Surgery_System.Services
{
    public class ServiceSurgery : IServiceSurgery
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string ImagePath;

        public ServiceSurgery(AppDbContext context, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            ImagePath = $"{_webHostEnvironment.WebRootPath}/{FileSetting.ImagePath}";
        }
        public async Task<IEnumerable<Surgery>> GetAllSurgeriesAsync()
        {
            return await _context.Surgeries.
                AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.SurgeryDevices)
                .ThenInclude(sd => sd.Device)
                .ToListAsync();
        }
        public Surgery? GetById(int id)
        {
            return _context.Surgeries
                .AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.SurgeryDevices)
                .ThenInclude(sd => sd.Device)
                .FirstOrDefault(s => s.Id == id);
        }
        public async Task CreateSurgeryAsync(CreateSurgeryVM model)
        {
            var PhoteName =await SaveImageAsync(model.Image);
            var surgery = _mapper.Map<Surgery>(model);
            surgery.ImageUrl = PhoteName;
            await _context.Surgeries.AddAsync(surgery);
            await _context.SaveChangesAsync();
        }

        public async Task<Surgery?> EditSurgeryAsync(EditSurgeryVM model)
        {
            var surgery = await _context.Surgeries
                .Include(s => s.SurgeryDevices)
                .FirstOrDefaultAsync(s => s.Id == model.Id);

            if (surgery == null)
                return null;

            var hasImage = model.Image != null;
            var oldImage = surgery.ImageUrl;
            surgery.SurgeryDevices.Clear();
            _mapper.Map(model, surgery);
            if (hasImage)
            {
                var photoName = await SaveImageAsync(model.Image!);
                surgery.ImageUrl = photoName;
            }

            var effectedRows = await _context.SaveChangesAsync();

            if (effectedRows > 0)
            {
                if (hasImage && !string.IsNullOrEmpty(oldImage))
                {
                    var imagePath = Path.Combine(ImagePath, oldImage);
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);
                }
                return surgery;
            }
            else
            {
                if (hasImage)
                {
                    var imagePath = Path.Combine(ImagePath, surgery.ImageUrl);
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);
                }
                return null;
            }
        }
        public bool DeleteSurgery(int id)
        {
            var isDDeleted = false;
            var surgery = _context.Surgeries.Find(id);
            if (surgery == null)
            {
                return isDDeleted;
            }
            _context.Surgeries.Remove(surgery);
            var effectedRows = _context.SaveChanges();
            if(effectedRows>0)
            {
                isDDeleted = true;
                var imagePath = Path.Combine(ImagePath, surgery.ImageUrl);
                File.Delete(imagePath);
            }
            return isDDeleted;
        }
        private async Task<string> SaveImageAsync(IFormFile image)
        {
            var photoName = $"{Guid.NewGuid()}{Path.GetExtension(image.FileName)}";
            var fullPath = Path.Combine(ImagePath, photoName);
            using var stream = File.Create(fullPath);
            await image.CopyToAsync(stream);
            return photoName;
        }

    }
}
