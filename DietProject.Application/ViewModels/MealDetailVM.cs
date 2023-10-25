using DietProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.ViewModels;

public class MealDetailVM
{
    public Guid Id { get; set; }
    public Guid MealId { get; set; }
    public MealVM Meal { get; set; }
    public Guid FoodId { get; set; }
    public FoodVM Food { get; set; }
    public float Amount { get; set; }
}
