namespace Auth.Presentation.Models
{
    public class RegisterDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}