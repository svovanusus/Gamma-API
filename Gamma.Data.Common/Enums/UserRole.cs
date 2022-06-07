using System.ComponentModel;

namespace Gamma.Data.Common.Enums
{
    public enum UserRole
    {
        [Description("User")]
        User = 0,

        [Description("Super User")]
        SuperUser = 1,
    }
}
