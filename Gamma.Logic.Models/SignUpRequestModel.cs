namespace Gamma.Logic.Models
{
    public class SignUpRequestModel
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
