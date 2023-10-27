using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Concrete;
using DietProject.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Repositories;

public class MealRepository : BaseRepository<Meal>, IMealRepository
{
    public MealRepository(DietContext context) : base(context)
    {
    }
}
