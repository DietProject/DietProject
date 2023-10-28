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

public class MealService : IMealService
{
    private readonly IMealRepository mealRepository;
    public MealService(IMealRepository mealRepository)
    {
        this.mealRepository = mealRepository;
    }
    public async Task AddAsync(MealVM model)
    {
        await mealRepository.AddAsync(
            new Meal
            {
                Id = model.Id,
                MealType= (Domain.Enum.MealType)model.MealType,
                CreateDate=model.CreateDate,
                User = new User {
                    Id = model.UserId,
                    Name = model.User.Name,
                    Surname = model.User.Surname,
                    Email = model.User.Email,
                    Password = model.User.Password,
                    Height = model.User.Height,
                    Weight = model.User.Weight,
                    DateofBirth = model.User.DateofBirth
                }
            }
        );
    }

    public Task DeleteAsync(MealVM model)
    {
        return mealRepository.DeleteAsync(new Meal
        {
            Id = model.Id,
            MealType = (Domain.Enum.MealType)model.MealType,
            CreateDate = model.CreateDate,
            User = new User
            {
                Id = model.UserId,
                Name = model.User.Name,
                Surname = model.User.Surname,
                Email = model.User.Email,
                Password = model.User.Password,
                Height = model.User.Height,
                Weight = model.User.Weight,
                DateofBirth = model.User.DateofBirth
            }
        });
    }



    public IQueryable<MealVM> GetAll()
    {
        return mealRepository.GetAll().Select(s => new MealVM
        {
            Id = s.Id,
            MealType = (MealTypeVM)s.MealType,
            CreateDate = s.CreateDate,
            User = new UserVM
            {
                Id = s.User.Id,
                Name = s.User.Name,
                Surname = s.User.Surname,
                Email = s.User.Email,
                Password = s.User.Password,
                Height = s.User.Height,
                Weight = s.User.Weight,
                DateofBirth = s.User.DateofBirth
            }
        });
    }

    //BUNAAA BAAK KESINLIKLE


    public IQueryable<MealVM> GetAll(Expression<Func<MealVM, bool>> filter)
    {
        IQueryable<MealVM> bosQueryable = Enumerable.Empty<MealVM>().AsQueryable();
        return bosQueryable;
    }

	public Task<MealVM> GetAsyncById(Guid id)
	{
		throw new NotImplementedException();
	}

	public bool Update(MealVM model)
    {
        return mealRepository.Update(new Meal
        {
            Id = model.Id,
            MealType = (Domain.Enum.MealType)model.MealType,
            CreateDate = model.CreateDate,
            User = new User
            {
                Id = model.UserId,
                Name = model.User.Name,
                Surname = model.User.Surname,
                Email = model.User.Email,
                Password = model.User.Password,
                Height = model.User.Height,
                Weight = model.User.Weight,
                DateofBirth = model.User.DateofBirth
            }
        });
    }
}
