
using TaskComputer.Domain.Primitives;

namespace TaskComputer.Domain.Entities;

public partial class TbRolePermission : AggregateRoot
{
    public int IdRolePermission { get; set; }

    public int IdRole { get; set; }

    public int IdPermission { get; set; }

    public bool Active { get; set; }

    public bool Removed { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime DateUpdated { get; set; }

    public int? DateRemoved { get; set; }

    public int IdUserCreated { get; set; }

    public int IdUserAction { get; set; }

    public virtual TbPermission IdPermissionNavigation { get; set; } = null!;

    public virtual TbRole IdRoleNavigation { get; set; } = null!;
}
