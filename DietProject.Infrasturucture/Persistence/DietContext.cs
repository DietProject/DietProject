using DietProject.Domain.Abstract;
using DietProject.Domain.Concrete;
using DietProject.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Persistence;

public class DietContext:DbContext
{
    public DietContext(DbContextOptions<DietContext> options):base(options)
    {
        
    }
    public DbSet<Food> Foods { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealDetail> MealDetails { get; set; }
    public DbSet<User> Users { get; set; }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>()) 
        {
            switch(entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreateDate = DateTime.Now;
                    break;
                //case EntityState.Deleted:
                    
                //    break;
                case EntityState.Modified:
                    if (entry.Entity.IsActive==false)
                    {
                        entry.Entity.DeletedDate = DateTime.Now;
                        break;
                    }
                    entry.Entity.UpdateDate = DateTime.Now;
                    break;
                    default: break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("No connection string!");
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new FoodConfiguration().Configure(modelBuilder.Entity<Food>());
        new MealConfiguration().Configure(modelBuilder.Entity<Meal>());
        new MealDetailConfiguration().Configure(modelBuilder.Entity<MealDetail>());

        base.OnModelCreating(modelBuilder);
    }
}
