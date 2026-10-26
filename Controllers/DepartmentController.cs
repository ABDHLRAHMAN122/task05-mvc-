using System.Runtime.Intrinsics.Arm;
using assignment02.Models;
using assignment02.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace assignment02.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly DepartmentBL depBL = new DepartmentBL();
        public IActionResult index()
        {
            List<Department> depList = depBL.ShowAll();   

            return View("Index",depList);
        }

        public IActionResult details(int id)
        {
            Department dep = depBL.getdetails(id);

            return View("details",dep);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        
        public IActionResult SaveAdd(Department dept)
        {
            ModelState.Remove(nameof(Department.students));
            ModelState.Remove(nameof(Department.courses));
            ModelState.Remove(nameof(Department.teachrs));
            if (ModelState.IsValid)
            {
                depBL.Add(dept);
                return RedirectToAction(nameof(index));
            }
            return View("Add",dept);
        }
        public IActionResult DepartmentStudentDetails(int id)
        {
            var dept = depBL.getdetails(id);
            if (dept == null) return NotFound();

            var studentsOver25 = depBL.GetStudentsExceeding25(id);
            string state = depBL.GetDepartmentState(id);

            var viewModel = new DepartmentDetailsViewModel
            {
                DepartmentName = dept.Name,
                DepartmentState = state,
                StudentsExceeding25 = new SelectList(studentsOver25, "Id", "Name")
            };

            return View("DepartmentStudentDetails", viewModel);
        }
        public IActionResult Edit(int id)
        {
            Department dep = depBL.getdetails(id);

            
            return View("Edit");

        }
        public IActionResult SaveEdit(Department department, int id)
        {
            if (ModelState.IsValid)
            {
                Department Olddep = depBL.getdetails(id);
                Olddep.Name = department.Name;
                Olddep.Id = department.Id;
                Olddep.mgrname = department.mgrname;
                depBL.SaveInDB();
                return RedirectToAction(nameof(Index));
            }
            return View("Edit", department);
        }


    }
}
