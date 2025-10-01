namespace Surgery_System.Helpers
{
    public class MaxSizeAttribute : ValidationAttribute
    {
        private readonly int _MaxSize;

        public MaxSizeAttribute(int maxSize)
        {
            _MaxSize = maxSize;
        }
        protected override ValidationResult? IsValid(object? value, 
            ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file == null)
            {
                return ValidationResult.Success;
            }
            if (file.Length>_MaxSize)
            {
                return new ValidationResult($"Image size must be less than {_MaxSize / 1024} KB.");
            }
            return ValidationResult.Success;


        }
    }
}
