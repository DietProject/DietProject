using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietProject.Application.CustomValidation
{
    public class DateTimeValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            
            if (value != null )
            {
                return false;
            }
            if ((DateTime)value>DateTime.Now)
            {
                return false;
            }
            return true;
        }


    }
}
