using TaskComputer.Domain.Primitives;

namespace TaskComputer.Domain.Entities;

public partial class TbRole : AggregateRoot
{
    public int IdRole { get; set; }

    public string NameRole { get; set; } = null!;

    public string CodeRole { get; set; } = null!;

    public bool Active { get; set; }

    public bool Removed { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateRemoved { get; set; }

    public DateTime DateUpdated { get; set; }

    public int IdUserAction { get; set; }

    public int IdUserCreated { get; set; }

    public virtual TbUser IdUserActionNavigation { get; set; } = null!;

    public virtual TbUser IdUserCreatedNavigation { get; set; } = null!;

    public virtual ICollection<TbRolePermission> TbRolePermissions { get; set; } = new List<TbRolePermission>();

    public virtual ICollection<TbUser> TbUsers { get; set; } = new List<TbUser>();
}
