using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.Validators
{
    public class DateYearsOldValidatorAttribute : ValidationAttribute
    {
        public DateYearsOldValidatorAttribute() { }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime dt = (DateTime)value;
                if (dt < DateTime.Now.AddYears(-18))
                {
                    return true;
                }
            }
            return false;
        }
    }
}