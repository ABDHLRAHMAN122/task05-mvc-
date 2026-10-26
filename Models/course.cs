namespace assignment02.Models
{
    public class course
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }
        public int deptid { get; set; }

        public List<stucrsres> crstudent { get; set; }
        public Department crsdept { get; set; }
        public List<teacher> crsteacher { get; set; }
    }
}
