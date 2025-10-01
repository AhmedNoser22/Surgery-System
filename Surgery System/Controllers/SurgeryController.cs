namespace Surgery_System.Controllers
{
    public class SurgeryController : Controller
    {
        private readonly IServiceCategories _serviceCategories;
        private readonly IServiceDevices _serviceDevices;
        private readonly IServiceSurgery _serviceSurgery;
        private readonly IMapper _mapper;

        public SurgeryController(IServiceCategories serviceCategories, IServiceDevices serviceDevices, IServiceSurgery serviceSurgery, IMapper mapper)
        {
            _serviceCategories = serviceCategories;
            _serviceDevices = serviceDevices;
            _serviceSurgery = serviceSurgery;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var surgeries = await _serviceSurgery.GetAllSurgeriesAsync();
            return View(surgeries);
        }
        public IActionResult Details(int id)
        {
            var surgery = _serviceSurgery.GetById(id);
            if (surgery == null)
            {
                return NotFound();
            }
            return View(surgery);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateSurgeryVM model = new()
            {
                Categories = _serviceCategories.GetAllCategories().ToList(),
                Devices = _serviceDevices.GetAllDevices().ToList()
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateSurgeryVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories =_serviceCategories.GetAllCategories().ToList();
                model.Devices = _serviceDevices.GetAllDevices().ToList();
                return View(model);
            }
            await _serviceSurgery.CreateSurgeryAsync(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var surgery = _serviceSurgery.GetById(id);
            if (surgery == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<EditSurgeryVM>(surgery);
            model.Categories = _serviceCategories.GetAllCategories().ToList();
            model.Devices = _serviceDevices.GetAllDevices().ToList();
            model.ImageUrl = surgery.ImageUrl; 

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(EditSurgeryVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = _serviceCategories.GetAllCategories().ToList();
                model.Devices = _serviceDevices.GetAllDevices().ToList();
                return View(model);
            }
            var updatedSurgery = await _serviceSurgery.EditSurgeryAsync(model);
            if(updatedSurgery==null) return BadRequest("Failed to update surgery. Please try again.");
            return RedirectToAction("Index");
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var surgery = _serviceSurgery.GetById(id);
            return surgery == null ? BadRequest() : Ok();
        }
    }
}
