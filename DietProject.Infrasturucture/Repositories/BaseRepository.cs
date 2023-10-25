using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Abstract;
using DietProject.Infrasturucture.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrasturucture.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
    private readonly DietContext _context;
    public BaseRepository(DietContext context)
    {
        _context = context;
    }
    public async Task AddAsync(T entity)
    {
       await _context.Set<T>().AddAsync(entity);
       await _context.SaveChangesAsync();
    }

    public bool Delete(T entity)
    {
        if (_context.Set<T>().Find(entity.Id) !=null)
        {
            entity.IsActive = false;
            _context.SaveChangesAsync();
            return true;
        }     
        return false;
    }

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _context.Set<T>().Where(filter);
    }

    public bool Update(T entity)
    {
        if (_context.Set<T>().Find(entity.Id) != null)
        {
            _context.Entry(entity).State =EntityState.Modified;
            _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
