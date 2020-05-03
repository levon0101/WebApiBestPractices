using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiBestPractices.Entities.ValidationAttributes
{
    public class MinYearAttribute : ValidationAttribute
    {
        private readonly int _year;

        public MinYearAttribute(int year)
        {
            _year = year;
        }

        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {

            var date = (DateTime) value;

            if(date.Year < _year) return  new ValidationResult($"Year can't be less then {_year}");
            //var movie = (Movie)validationContext.ObjectInstance;
            //var releaseYear = ((DateTime)value).Year;

            //if (movie.Genre == Genre.Classic && releaseYear > Year)
            //{
            //    return new ValidationResult(GetErrorMessage());
            //}

            return ValidationResult.Success;
        }
    }
}
