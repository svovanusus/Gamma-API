using Gamma.Data.Common.Enums;

namespace Gamma.Data.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public UserRole Role { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
