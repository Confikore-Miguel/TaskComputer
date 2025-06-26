using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskComputer.Domain.Entities;

namespace TaskComputer.Infrastructure.Persistence.Configurations
{
    public class TbPermissionConfiguration : IEntityTypeConfiguration<TbPermission>
    {
        public void Configure(EntityTypeBuilder<TbPermission> builder)
        {
            builder.HasKey(e => e.IdPermission);

            builder.ToTable("TB_Permission");

            builder.Property(e => e.DateCreated).HasColumnType("datetime");
            builder.Property(e => e.DateRemoved).HasColumnType("datetime");
            builder.Property(e => e.PermissionName).HasMaxLength(100);

            builder.HasOne(d => d.IdUserActionNavigation).WithMany(p => p.TbPermissionIdUserActionNavigations)
                .HasForeignKey(d => d.IdUserAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Permission_TB_User_Action");

            builder.HasOne(d => d.IdUserCreatedNavigation).WithMany(p => p.TbPermissionIdUserCreatedNavigations)
                .HasForeignKey(d => d.IdUserCreated)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Permission_TB_User_Created");
        }
    }
}
