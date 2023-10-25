using DietProject.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Domain.Concrete;

public class User :BaseEntity
{
    public string Email { get; set; }

    public string Password { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }

    public byte Height { get; set; }

    public float Weight { get; set; }

    public DateTime DateofBirth { get; set; }
}
