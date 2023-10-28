using DietProject.Application.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.Contract.IServices.IBase;

public interface IBaseService<T> where T : BaseVM, new()
{
    Task<T> GetAsyncById(Guid id);
    Task AddAsync(T model);
    Task DeleteAsync(T model);
    bool Update(T model);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T, bool>> filter);
}
