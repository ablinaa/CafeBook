using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeBook.Models
{
    public class Book:IValidatableObject
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string PublishedYear { get; set; }
        public string Publisher { get; set; }

        public int BookTypeId { get; set; }
        public BookType BookType { get; set; }

        public List<RentSchedule> RentSchedule { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int i = 0;
            i = Convert.ToInt32(PublishedYear);
            if (BookType.Name.Equals("Roman") && i>=1995)
            {
                yield return new ValidationResult(
                    $"The published year must be less than 1995",
                    new[] { "ReleaseDate" });
            }
        }
    }
}
