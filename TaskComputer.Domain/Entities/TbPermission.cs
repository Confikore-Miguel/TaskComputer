using TaskComputer.Domain.Primitives;

namespace TaskComputer.Domain.Entities;

public partial class TbPermission : AggregateRoot
{
    public int IdPermission { get; set; }

    public string? PermissionName { get; set; }

    public int Level { get; set; }

    public string Url { get; set; } = null!;

    public bool Active { get; set; }

    public bool Removed { get; set; }

    public DateTime DateCreated { get; set; }

    public int? DateUpdated { get; set; }

    public DateTime? DateRemoved { get; set; }

    public int IdUserCreated { get; set; }

    public int IdUserAction { get; set; }

    public virtual TbUser IdUserActionNavigation { get; set; } = null!;

    public virtual TbUser IdUserCreatedNavigation { get; set; } = null!;

    public virtual ICollection<TbRolePermission> TbRolePermissions { get; set; } = new List<TbRolePermission>();
}
