namespace Surgery_System.Helpers
{
    public class AllowedAttribute:ValidationAttribute
    {
        private readonly string _AllowedExtensions;

        public AllowedAttribute(string allowedExtensions)
        {
            _AllowedExtensions = allowedExtensions;
        }
        protected override ValidationResult? IsValid(object? value,
            ValidationContext validationContext)
        {
            var valueAsIFormFile = value as IFormFile;
            if (valueAsIFormFile == null)
            {
                return ValidationResult.Success;
            }
            var fileExtension = Path.GetExtension(valueAsIFormFile.FileName);
            var IsAllowed = _AllowedExtensions.Split(',').Contains(fileExtension, StringComparer.OrdinalIgnoreCase);
            if (!IsAllowed)
            {
                return new ValidationResult($"Allowed extensions are: {_AllowedExtensions}");
            }
            return ValidationResult.Success;

        }
    }
}
