using DietProject.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.ViewModels;

public class UserVM
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public byte Height { get; set; }
    public float Weight { get; set; }
    public DateTime DateofBirth { get; set; }
    public virtual IEnumerable<MealVM> Meals { get; set; }
}
