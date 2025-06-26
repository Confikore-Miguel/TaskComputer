using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskComputer.Infrastructure.Entities;

namespace TaskComputer.Infrastructure.Persistence.Configuration
{

    public class TbRolePermissionConfiguration : IEntityTypeConfiguration<TbRolePermission>
    {
        public void Configure(EntityTypeBuilder<TbRolePermission> builder)
        {
            builder.HasKey(e => e.IdRolePermission);

            builder.ToTable("TB_Role_Permission");

            builder.Property(e => e.DateCreated).HasColumnType("datetime");
            builder.Property(e => e.DateUpdated).HasColumnType("datetime");

            builder.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.TbRolePermissions)
                .HasForeignKey(d => d.IdPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Role_Permission_TB_Permission");

            builder.HasOne(d => d.IdRoleNavigation).WithMany(p => p.TbRolePermissions)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Role_Permission_TB_Role");
        }
    }
}
