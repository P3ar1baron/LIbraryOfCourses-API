using LibraryOfCourses.API.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace LibraryOfCourses.API.Models
{
    [CourseTitleMustBeDifferentFromDescription(
        ErrorMessage = "Title must be different from a description")]
    public abstract class CourseForManipulationDto
    {
        [Required(ErrorMessage = "You should fill out a title.")]
        [MaxLength(100, ErrorMessage = "The title shouldn't have more than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "You should fill out a description.")]
        [MaxLength(500, ErrorMessage = "The description shouldn't have more than 500 characters.")]
        public virtual string Description { get; set; }
    }
}
