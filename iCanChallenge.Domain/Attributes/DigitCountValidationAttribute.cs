using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCanChallenge.Domain.Attributes
{
    public class DigitCountValidationAttribute : ValidationAttribute
    {
        private readonly int _maxDigits;

        public DigitCountValidationAttribute(int maxDigits)
        {
            _maxDigits = maxDigits;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            int intValue = (int)value;
            string valueString = intValue.ToString();
            return valueString.Length <= _maxDigits;
        }
    }
}
