using DietProject.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasQueryFilter(x => x.IsActive==true);
        builder.Property(x=>x.Email).HasMaxLength(50).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Password).HasMaxLength(20).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Surname).HasMaxLength(50).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Height).HasMaxLength(300).HasColumnType("tinyint").IsRequired();

        builder.Property(x => x.Weight).HasMaxLength(300).HasColumnType("tinyint").IsRequired();

        builder.HasMany(x => x.Meals)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
    }
}
