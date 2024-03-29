﻿using DietProject.Application.Contract.IRepository;
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

public class UserService : IUserService
{
	private readonly IUserRepository userRepository;
	public UserService(IUserRepository userRepository)
	{
		this.userRepository = userRepository;
	}
	public async Task AddAsync(UserVM model)
	{
		if (!ContainsUser(model))
		{
			await userRepository.AddAsync(
			new User
			{

				Name = model.Name,
				Surname = model.Surname,
				Email = model.Email,
				Password = model.Password,
				Height = model.Height,
				Weight = model.Weight,
				DateofBirth = model.DateofBirth
			});
		};
	}

	public Task DeleteAsync(UserVM model)
	{
		return userRepository.DeleteAsync(new User
		{
			Id = model.Id,
			Name = model.Name,
			Surname = model.Surname,
			Email = model.Email,
			Password = model.Password,
			Height = model.Height,
			Weight = model.Weight,
			DateofBirth = model.DateofBirth
		});
	}

	public IQueryable<UserVM> GetAll()
	{
		return userRepository.GetAll().Select(s => new UserVM
		{
			Id = s.Id,
			Name = s.Name,
			Surname = s.Surname,
			Email = s.Email,
			Height = s.Height,
			Weight = s.Weight,
			DateofBirth = s.DateofBirth
		});
	}

	//BUNAAA BAAK KESINLIKLE


	public IQueryable<UserVM> GetAll(Expression<Func<UserVM, bool>> filter)
	{
		IQueryable<UserVM> bosQueryable = Enumerable.Empty<UserVM>().AsQueryable();
		return bosQueryable;
	}

	public bool ContainsUser(UserVM vm)
	{
		var entity = userRepository.GetAll().FirstOrDefault(x => x.Email == vm.Email);
		if (entity is null)
		{
			return false;
		}
		return true;
	}

	public bool Update(UserVM model)
	{
		return userRepository.Update(new User
		{
			Id = model.Id,
			Name = model.Name,
			Surname = model.Surname,
			Email = model.Email,
			Password = model.Password,
			Height = model.Height,
			Weight = model.Weight,
			DateofBirth = model.DateofBirth
		});
	}

	public async Task<UserVM> GetAsyncById(Guid id)
	{

		var model = await userRepository.GetAsyncById(id);

		return new UserVM()
		{
			Id = model.Id,
			Name = model.Name,
			Surname = model.Surname,
			Email = model.Email,
			Password = model.Password,
			Height = model.Height,
			Weight = model.Weight,
			DateofBirth = model.DateofBirth
		};

	}


}
