using DietProject.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Domain.Concrete;

public class MealDetail :BaseEntity
{
    public Guid MealId { get; set; }
    public Meal Meal { get; set; }
    public Guid FoodId { get; set; }
    public Food Food { get; set; }


}
