using assignment02.Data.DigitalDBcontext;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace assignment02.Models
{
    public class DepartmentBL 
    {
        DigitalDBContexts cont = new DigitalDBContexts();

        public List<Department> ShowAll()
        {
            return cont.Departments
                       .Include(e => e.students)
                       .Include(e => e.courses)
                       .Include(e => e.teachrs)
                       .ToList();
                       
        }
        public Department getdetails(int id)
        {
            return cont.Departments.FirstOrDefault(e => e.Id == id);
        }  
          public void Add(Department dept)
        {
            cont.Departments.Add(dept);
            cont.SaveChanges();
        }

        public List<student> GetStudentsExceeding25(int DeptId)
        {
            return cont.students
                .Where(s => s.deptid == DeptId && s.Age > 25)
                .ToList();
        }

        public string GetDepartmentState(int deptId)
        {
            int totalStudents = cont.students.Count(s => s.deptid == deptId);
            return totalStudents > 50 ? "Main" : "Branch";
        }
        public void SaveInDB()
        {
            cont.SaveChanges();
        }

    }
}
