using assignment02.Data.DigitalDBcontext;
using Microsoft.EntityFrameworkCore;
using assignment02.viewmodel;
namespace assignment02.Models
{
    public class studentBL
    {
        DigitalDBContexts context = new DigitalDBContexts();

        public List<student> GetAll()
        {
            return context.students
                          .Include(s => s.studept)
                          .Include(b => b.stucourse)
                          .ToList();
        }
        public student getbyid(int id)
        {
            return context.students
                          .FirstOrDefault(E => E.Id == id);
        }
        public void Add(student stud)
        {
            context.students.Add(stud);    
            context.SaveChanges();
        }
        public void SaveInDB()
        {
            context.SaveChanges();
        }
        public void Delete(student st)
        {
            context.students.Remove(st);
            context.SaveChanges();
        }
        public PagedResult<student> GetPagedStudents(string searchName, int? deptId, int pageNumber, int pageSize)
        {
            var query = context.students.Include(s => s.studept).AsQueryable();

            if (!string.IsNullOrEmpty(searchName))
            {
                query = query.Where(s => s.Name.Contains(searchName));
            }

            if (deptId.HasValue && deptId.Value > 0)
            {
                query = query.Where(s => s.deptid == deptId.Value);
            }

            int totalItems = query.Count();

            var items = query.Skip((pageNumber - 1) * pageSize)
                             .Take(pageSize)
                             .ToList();

            return new PagedResult<student>
            {
                Items = items,
                PageNumber = pageNumber,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }

    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
