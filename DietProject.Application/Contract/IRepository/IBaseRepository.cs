using DietProject.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.Contract.IRepository;

public interface IBaseRepository<T> where T:BaseEntity,new() 
{
    Task AddAsync(T entity);
    bool Delete(T entity);
    bool Update(T entity);
    IQueryable<T> GetAll();
    IQueryable<T> GetAll(Expression<Func<T,bool>> filter);
}
