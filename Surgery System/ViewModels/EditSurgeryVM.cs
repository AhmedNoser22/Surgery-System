namespace Surgery_System.ViewModels
{
    public class EditSurgeryVM
    {
        public int Id { get; set; }
        [Display(Name = "Surgery Name")]
        [Required(ErrorMessage = "Surgery Name is required.")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Surgery Category")]
        [Required(ErrorMessage = "Surgery Category is required.")]
        public int CategoryId { get; set; }
        [Display(Name = "Medical Device")]
        [Required(ErrorMessage = "At least one device is required.")]
        public List<int> DeviceIds { get; set; } = default!;
        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = string.Empty;
        [AllowedAttribute(FileSetting.AllowedImageTypes), MaxSizeAttribute(FileSetting.MaxImageSize)]
        public IFormFile? Image { get; set; }=default!;
        public string? ImageUrl { get; set; }
    }
}
