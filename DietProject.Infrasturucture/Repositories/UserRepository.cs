using DietProject.Application.Contract.IRepository;
using DietProject.Domain.Concrete;
using DietProject.Infrasturucture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Infrasturucture.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(DietContext context) : base(context)
    {
    }
}
