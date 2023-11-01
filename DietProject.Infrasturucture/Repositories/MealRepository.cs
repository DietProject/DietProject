using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Concrete;
using DietProject.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Repositories;

public class MealRepository : BaseRepository<Meal>, IMealRepository
{
    private readonly DietContext _context;
    public MealRepository(DietContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Meal> CreateAsync(Meal meal)
    {
        await _context.Meals.AddAsync(meal);
        await _context.SaveChangesAsync();
        return meal;
    }

    //public Task<List<Meal>> GetAll(User user)
    //{
    //   return await _context.Meals.Include(x => x.MealDetails).ThenInclude(x => x.Food).Where(x => x.UserId == user.Id).Select(x => new
    //    {
    //        x.
    //    }).ToList()
    //}

    // Bu kod ile iki tabloyu birbirine bağlıyoruz.

}
