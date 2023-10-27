using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Concrete;
using DietProject.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrastructure.Repositories;

public class MealDetailRepository : BaseRepository<MealDetail>, IMealDetailRepository
{
    public MealDetailRepository(DietContext context) : base(context)
    {
    }
}
