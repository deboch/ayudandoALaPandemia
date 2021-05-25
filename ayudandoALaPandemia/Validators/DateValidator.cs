using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ayudandoALaPandemia.Validators
{
    public class DateValidatorAttribute : ValidationAttribute
    {
        public DateValidatorAttribute() {}
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                DateTime dt = (DateTime)value;
                if (dt >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
}