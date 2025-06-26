using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskComputer.Domain.Entities;

namespace TaskComputer.Infrastructure.Persistence.Configuration
{
    public class TbRoleConfiguration : IEntityTypeConfiguration<TbRole>
    {
        public void Configure(EntityTypeBuilder<TbRole> builder)
        {
            builder.HasKey(e => e.IdRole);

            builder.ToTable("TB_Role");

            builder.Property(e => e.IdRole)
                .ValueGeneratedNever()
                .HasColumnName("Id_Role");
            builder.Property(e => e.CodeRole)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.DateCreated).HasColumnType("datetime");
            builder.Property(e => e.DateRemoved).HasColumnType("datetime");
            builder.Property(e => e.DateUpdated).HasColumnType("datetime");
            builder.Property(e => e.NameRole).HasMaxLength(100);

            builder.HasOne(d => d.IdUserActionNavigation).WithMany(p => p.TbRoleIdUserActionNavigations)
                .HasForeignKey(d => d.IdUserAction)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Role_TB_User");

            builder.HasOne(d => d.IdUserCreatedNavigation).WithMany(p => p.TbRoleIdUserCreatedNavigations)
                .HasForeignKey(d => d.IdUserCreated)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_Role_TB_User_Created");
        }
    }
}
