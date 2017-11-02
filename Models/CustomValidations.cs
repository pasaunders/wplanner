using System;
using System.ComponentModel.DataAnnotations;

namespace weddingPlanner.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d > DateTime.Now;
        }
    }
}