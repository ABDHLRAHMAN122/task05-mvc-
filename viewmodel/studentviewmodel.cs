using System.ComponentModel.DataAnnotations;
using assignment02.Models;
namespace assignment02.viewmodel
{
    public class studentviewmodel
    {
        
        public int Id { get; set; }
        [Display(Name="Full Name")]
        [Required]
        [MinLength(3, ErrorMessage = "shoud be more than 3 letters")]
        [MaxLength(30, ErrorMessage = "shoud be less than 30 letters")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Must be characters and spaces")]
        public string Name { get; set; }
        [Required(ErrorMessage = "حقل العمر مطلوب ولا يمكن تركه فارغاً")]

        [Range(18, 30, ErrorMessage = "must be between 18 and 30")]
        public int Age { get; set; }
        [Required(ErrorMessage = "must choose department")]
        [Range(1, int.MaxValue, ErrorMessage = "must choose valid department")]
        public int? deptid { get; set; }

        public List<Department>? Deptlist { get; set; }

    }
}
