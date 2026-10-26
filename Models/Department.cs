using System.ComponentModel.DataAnnotations;

namespace assignment02.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [MinLength(3, ErrorMessage = "shoud be more than 3 letters")]
        [MaxLength(30, ErrorMessage = "shoud be less than 30 letters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be characters and spaces")]
        public string Name { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        [MinLength(3, ErrorMessage = "shoud be more than 3 letters")]
        [MaxLength(30, ErrorMessage = "shoud be less than 30 letters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be characters and spaces")]
        public string mgrname { get; set; }

        public List<student> students { get; set; }
        public List<course> courses { get; set; }
        public List<teacher> teachrs { get; set; }

    }
}
