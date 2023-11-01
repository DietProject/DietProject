using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.ViewModels;
using DietProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.Services;

//!!!!!!!!!!!!    MEAL DETAIL TAMAMEN BAKILACAK    !!!!!!!!
public class MealDetailService : IMealDetailService
{
    private readonly IMealDetailRepository mealDetailRepository;

    public MealDetailService(IMealDetailRepository mealDetailRepository)
    {
        this.mealDetailRepository = mealDetailRepository;
    }

    public async Task AddAsync(MealDetailVM model)
    {
        await mealDetailRepository.AddAsync(
            new MealDetail
            {
                MealId = model.MealId,
                FoodId = model.FoodId,
                Amount = model.Amount,
            }
        );
    }


    public Task DeleteAsync(MealDetailVM model)
    {
        return mealDetailRepository.DeleteAsync(new MealDetail
        {
            Id = model.Id,
            MealId = model.MealId,
            FoodId = model.FoodId,
            Amount = model.Amount,
        });
    }


    public IQueryable<MealDetailVM> GetAll()
    {
        return mealDetailRepository.GetAll().Select(s => new MealDetailVM
        {
            Id = s.Id,
            MealId = s.Meal.Id,
            Meal = new MealVM
            {
                Id = s.Meal.Id,
                UserId = s.Meal.UserId,
                User = new UserVM
                {
                    Id = s.Meal.User.Id,
                    Name = s.Meal.User.Name,
                    Surname = s.Meal.User.Surname,
                    Email = s.Meal.User.Email,
                    Password = s.Meal.User.Password,
                    Height = s.Meal.User.Height,
                    Weight = s.Meal.User.Weight,
                    DateofBirth = s.Meal.User.DateofBirth,
                },
                MealType = (MealTypeVM)s.Meal.MealType,
                MealDate = s.Meal.MealDate,
            },
            FoodId = s.FoodId,
            Food = new FoodVM
            {
                Id = s.Food.Id,
                Description = s.Food.Description,
                Name = s.Food.Name,
                Photo = s.Food.Photo,
                Portion = (PortionVM)s.Food.Portion,
                Calorie = s.Food.Calorie
            },
            Amount = s.Amount,
        });
    }

    //BUNAAA BAAK KESINLIKLE


    public IQueryable<MealDetailVM> GetAll(Expression<Func<MealDetailVM, bool>> filter)
    {
        IQueryable<MealDetailVM> bosQueryable = Enumerable.Empty<MealDetailVM>().AsQueryable();
        return bosQueryable;
    }

    public async Task<MealDetailVM> GetAsyncById(Guid id)
    {
        var model = await mealDetailRepository.GetAsyncById(id);
        return new MealDetailVM
        {
            Id = model.Id,
            MealId = model.MealId,
            FoodId = model.FoodId,
            Amount = model.Amount,
        };
    }

    public bool Update(MealDetailVM model)
    {
        return mealDetailRepository.Update(new MealDetail
        {
            Id = model.Id,
            MealId = model.MealId,
            FoodId = model.FoodId,
            Amount = model.Amount,
        });
    }
}
