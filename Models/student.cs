namespace assignment02.Models
{
    public class student
    {

        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public int? deptid { get; set; }

        public List<stucrsres> stucourse { get; set; }
        public Department studept { get; set; }

    }
}
