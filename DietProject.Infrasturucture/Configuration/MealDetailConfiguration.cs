using DietProject.Domain.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrasturucture.Configuration;

public class MealDetailConfiguration : IEntityTypeConfiguration<MealDetail>
{
    public void Configure(EntityTypeBuilder<MealDetail> builder)
    {
        builder.HasQueryFilter(x => x.IsActive);
    }
}
