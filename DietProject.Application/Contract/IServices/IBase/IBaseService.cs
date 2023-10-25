using DietProject.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.Contract.IServices.IBase;

public interface IBaseService<T> where T : BaseVM, new()
{
    Task AddAsync(T model);
    bool Delete(T model);
    bool Update(T model);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
}
