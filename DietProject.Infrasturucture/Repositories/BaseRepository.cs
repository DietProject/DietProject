using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Abstract;
using DietProject.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Repositories;

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
	public async Task DeleteAsync(T entity)
    {
        var result = _context.Set<T>().Find(entity.Id);

		if (result != null)
        {
            result.IsActive =false;
            _context.Update(result)
;           await _context.SaveChangesAsync();
           
        }
       
	}

    public IQueryable<T> GetAll()
    {
        return _context.Set<T>();
    }

    public IQueryable<T> GetAll(Expression<Func<T, bool>> filter)
    {
        return _context.Set<T>().Where(filter);
    }

	public async Task<T> GetAsyncById(Guid id)
	{
        return await _context.Set<T>().FirstOrDefaultAsync(x=> x.Id == id);
	}

	public bool Update(T entity)
    {
        if (_context.Set<T>().Find(entity.Id) != null)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return true;
        }
        return false;
    }


}
