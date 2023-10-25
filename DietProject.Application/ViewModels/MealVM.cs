using DietProject.Domain.Concrete;
using DietProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.ViewModels;

public class MealVM
{   
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public UserVM User { get; set; }
    public MealType MealType { get; set; }
    public DateTime CreateDate { get; set; }
    public IEnumerable<MealDetailVM> MealDetails { get; set; }
}
