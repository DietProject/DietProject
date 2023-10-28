using DietProject.Application.Contract.IRepository;
using DietProject.Application.Contract.IServices;
using DietProject.Application.Contract.IServices.IBase;
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

public class FoodService : IFoodService
{
    private readonly IFoodRepository foodRepository;
    public FoodService(IFoodRepository foodRepository)
    {
        this.foodRepository = foodRepository;
    }
    public async Task AddAsync(FoodVM model)
    {
        await foodRepository.AddAsync(
            new Food
            {
                Id = model.Id,
                Name = model.Name,
                Calorie = model.Calorie,
                Description = model.Description,
                Photo = model.Photo,
                Portion = model.Portion
            }
        );
    }

    public Task DeleteAsync(FoodVM model)
    {
        return foodRepository.DeleteAsync(new Food
        {
            Id = model.Id,
            Name = model.Name,
            Calorie = model.Calorie,
            Description = model.Description,
            Photo = model.Photo,
            Portion = model.Portion
        });
    }



    public IQueryable<FoodVM> GetAll()
    {
        return foodRepository.GetAll().Select(s => new FoodVM
        {
            Id = s.Id,
            Name = s.Name,
            Calorie = s.Calorie,
            Description = s.Description,
            Photo = s.Photo,
            Portion = s.Portion
        });
    }

    //BUNAAA BAAK KESINLIKLE


    public IQueryable<FoodVM> GetAll(Expression<Func<FoodVM, bool>> filter)
    {
        IQueryable<FoodVM> bosQueryable = Enumerable.Empty<FoodVM>().AsQueryable();
        return bosQueryable;
    }

	public Task<FoodVM> GetAsyncById(Guid id)
	{
		throw new NotImplementedException();
	}

	public bool Update(FoodVM model)
    {
        return foodRepository.Update(new Food
        {
            Id = model.Id,
            Name = model.Name,
            Calorie = model.Calorie,
            Description = model.Description,
            Photo = model.Photo,
            Portion = model.Portion
        });
    }


}
