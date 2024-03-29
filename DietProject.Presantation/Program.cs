
using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.Services;
using DietProject.Domain.Abstract;
using DietProject.Infrastructure.Persistence;
using DietProject.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DietProject.Presantation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DietContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("cstring")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)) ;

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();


            builder.Services.AddScoped<IFoodService, FoodService>();
            builder.Services.AddScoped<IFoodRepository, FoodRepository>();

            builder.Services.AddScoped<IMealRepository, MealRepository>();
            builder.Services.AddScoped<IMealService, MealService>();

            builder.Services.AddScoped<IMealDetailRepository, MealDetailRepository>();
            builder.Services.AddScoped<IMealDetailService, MealDetailService>();

            //builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}