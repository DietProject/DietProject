using DietProject.Domain.Concrete;
using DietProject.Infrasturucture.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrasturucture.Persistence;

public class DietContext:DbContext
{
    public DbSet<Food> Foods { get; set; }
    public DbSet<Meal> Meals { get; set; }
    public DbSet<MealDetail> MealDetails { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=STUFF\SQLEXPRESS;Database=DietProject;Trusted_Connection=True;TrustServerCertificate=True");
        }
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new UserConfiguration().Configure(modelBuilder.Entity<User>());
        new FoodConfiguration().Configure(modelBuilder.Entity<Food>());

        base.OnModelCreating(modelBuilder);
    }
}
