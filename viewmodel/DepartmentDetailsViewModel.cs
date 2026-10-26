using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment02.viewmodel
{
    public class DepartmentDetailsViewModel
    {
        public string DepartmentName { get; set; }
        public string DepartmentState { get; set; } // Main (>50) or Branch (<=50)

        // List for the DropDownList
        public SelectList StudentsExceeding25 { get; set; }
        public int SelectedStudentId { get; set; }
    }
}
