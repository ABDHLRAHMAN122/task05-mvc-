using System;
using assignment02.Data.DigitalDBcontext;
using assignment02.Models;
using assignment02.viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace assignment02.Controllers
{
    public class StudentController : Controller
    {
        studentBL stud = new studentBL();
        DepartmentBL dep = new DepartmentBL();
        public IActionResult Index(string searchName, int? deptId, int pageNumber = 1)
        {
            int PageSize = 5;
            student s = new student();
            var result = stud.GetPagedStudents(searchName, deptId, pageNumber, 5);

            ViewBag.Departments = dep.ShowAll();
            ViewBag.CurrentSearch = searchName;
            ViewBag.CurrentDeptId = deptId;
            ViewBag.PageNumber = result.PageNumber;
            ViewBag.TotalPages = result.TotalPages;

            return View("Index", result.Items);
        }

        public IActionResult Details(int id)
        {
            studentBL students = new studentBL();
            student students2 = students.getbyid(id);

             return View("Details",students2);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<Department> dept = dep.ShowAll();

            studentviewmodel studentviewmodel = new studentviewmodel()
            {
                Deptlist = dept
            };

           return View("Add", studentviewmodel);
        }
        [HttpPost]

        public IActionResult SaveAdd(studentviewmodel studSent)
        {
            if (ModelState.IsValid)
            {
                student newStud = new student()
                {
                    Name = studSent.Name,
                    Age = studSent.Age,
                    deptid = studSent.deptid
                };

                stud.Add(newStud); 
                stud.SaveInDB();

                return RedirectToAction(nameof(Index));
            }

            studSent.Deptlist = dep.ShowAll();
            return View("Add", studSent);
        }
        
        public IActionResult Edit(int id)
        {
            student stu = stud.getbyid(id);
            List<Department> dept = dep.ShowAll();

            studentviewmodel studentviewmodel = new studentviewmodel()
            {
                Name = stu.Name,
                Age = stu.Age,
                deptid = stu.deptid,
                Deptlist = dep.ShowAll()

            };
            return View("Edit", studentviewmodel);

        }
        public IActionResult SaveEdit(studentviewmodel studentVM, int id)
        {
            if (ModelState.IsValid)
            {
                student OldEmp = stud.getbyid(id);
                OldEmp.Name = studentVM.Name;
                OldEmp.Age = studentVM.Age;
                OldEmp.deptid = studentVM.deptid;

                stud.SaveInDB();
                return RedirectToAction(nameof(Index));
            }
            studentVM.Deptlist = dep.ShowAll();
            return View("Edit", studentVM);
        }
        public IActionResult Delete(int id)
        {
             return View("Delete", stud.getbyid(id));   
        }
        public IActionResult SaveDelete(int id)
        {
            student stud2 = stud.getbyid(id);
            if (stud2 != null)
            {
                stud.Delete(stud2);
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


    }
}
