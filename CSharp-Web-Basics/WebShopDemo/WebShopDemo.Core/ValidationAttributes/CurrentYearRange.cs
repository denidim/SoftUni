﻿using System.ComponentModel.DataAnnotations;

namespace WebShopDemo.Core.ValidationAttributes
{
    public class CurrentYearRange : ValidationAttribute
    {
        public CurrentYearRange(int minYear)
        {
            MinYear = minYear;
            this.ErrorMessage = $"Value should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; }

        public override bool IsValid(object? value)
        {
            if (value is int intValue)
            {
                if (intValue <= DateTime.UtcNow.Year
                    && intValue >= MinYear)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
  