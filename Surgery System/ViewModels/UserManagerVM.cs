namespace Surgery_System.ViewModels
{
    public class UserManagerVM
    {
        public string Id { get; set; } = default!;
        [Display(Name = "User Name")]
        public string Email { get; set; } = default!;
        public bool IsSelected { get; set; } = false;
    }
}
