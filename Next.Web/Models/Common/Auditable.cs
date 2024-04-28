namespace Next.Web.Models.Common;
public class Auditable : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
