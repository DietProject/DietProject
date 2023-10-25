using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Domain.Abstract;

public abstract class BaseEntity  // Bu class dan nesne üretilmediği için abstract yapılır.
{
    public Guid Id { get; set; } =Guid.NewGuid();
    public bool IsActive { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime UpdateDate { get; set; }
    public DateTime DeletedDate { get; set; }


}
