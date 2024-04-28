using Next.Web.Models.Common;

namespace Next.Web.Models;
public class User : Auditable
{
    public string FristName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PhoneNumber { get ; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public UserRole UserRole { get; set; }
}
