using DietProject.Domain.Abstract;
using DietProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Domain.Concrete;

public class Meal :BaseEntity
{
    public Guid UserId { get; set; }
    public User User{ get; set; }
    public MealType MealType { get; set; }
    public IEnumerable<MealDetail> MealDetails { get; set; }
}
