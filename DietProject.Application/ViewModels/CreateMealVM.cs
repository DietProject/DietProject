using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.ViewModels;

public class CreateMealVM
{
    public Guid UserId { get; set; }

    public UserVM User { get; set; }
    public MealTypeVM MealType { get; set; }
    public DateTime MealDate { get; set; }
    public Guid SelectedFoodId { get; set; }
    public IEnumerable<FoodVM> Foods { get; set; }
    public float Amount { get; set; }

}
