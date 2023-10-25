using DietProject.Application.Contract.IServices;
using DietProject.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.Services;

public class UserService : IUserService
{
    public Task AddAsync(UserVM model)
    {
        throw new NotImplementedException();
    }

    public bool Delete(UserVM model)
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserVM> GetAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<UserVM> GetAll(Expression<Func<UserVM, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public bool Update(UserVM model)
    {
        throw new NotImplementedException();
    }
}
