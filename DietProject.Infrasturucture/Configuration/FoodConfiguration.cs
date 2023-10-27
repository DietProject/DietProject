using DietProject.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Configuration;
public class FoodConfiguration : IEntityTypeConfiguration<Food>
{
    public void Configure(EntityTypeBuilder<Food> builder)
    {
        builder.HasQueryFilter(x => x.IsActive);
        builder.Property(x => x.Name).HasMaxLength(50).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Description).HasMaxLength(100).HasColumnType("varchar").IsRequired();
        builder.Property(x => x.Photo).HasColumnType("varchar").IsRequired();
    }
}
