using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.ViewModels;
using DietProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
           
            }
        );
    }


    public Task DeleteAsync(MealDetailVM model)
    {
        return mealDetailRepository.DeleteAsync(new MealDetail
        {
            Id = model.Id,
            Amount =model.Amount,
            Meal = new Meal
            {
                Id = model.Meal.Id,
            },
            Food = new Food 
            { 
                Id = model.Meal.Id,
            }
           
        });
    }


    public IQueryable<MealDetailVM> GetAll()
    {
        return mealDetailRepository.GetAll().Select(s => new MealDetailVM
        {
            
            
        });
    }

    //BUNAAA BAAK KESINLIKLE


    public IQueryable<MealDetailVM> GetAll(Expression<Func<MealDetailVM, bool>> filter)
    {
        IQueryable<MealDetailVM> bosQueryable = Enumerable.Empty<MealDetailVM>().AsQueryable();
        return bosQueryable;
    }

	public Task<MealDetailVM> GetAsyncById(Guid id)
	{
		throw new NotImplementedException();
	}

	public bool Update(MealDetailVM model)
    {
        return mealDetailRepository.Update(new MealDetail
        {
            Id = model.Id,
            Amount = model.Amount,
            Meal = new Meal
            {
                Id = model.Meal.Id,
            },
            Food = new Food
            {
                Id = model.Meal.Id,
            }

        });
    }
}
