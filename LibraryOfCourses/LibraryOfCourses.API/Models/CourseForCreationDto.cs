using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace LibraryOfCourses.API.Models
{
    public class CourseForCreationDto : IValidatableObject
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(150)]
        public string Description { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Title == Description)
            {
                yield return new ValidationResult(
                    "The provided description should be different from the title.",
                    new[] { "CourseForCreationDto" });
            }
        }
    }
}
