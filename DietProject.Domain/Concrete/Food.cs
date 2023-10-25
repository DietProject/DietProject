using DietProject.Domain.Abstract;
using DietProject.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Domain.Concrete;

public class Food : BaseEntity

{
    public string Name { get; set; }

    public string Description { get; set; }

    public float Calorie { get; set; }

    public string? Photo { get; set; }

    public Portion Portion{ get; set; }
}
