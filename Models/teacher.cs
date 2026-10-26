namespace assignment02.Models
{
    public class teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public decimal salary { get; set; }
        public string address { get; set; }
        public int courseid { get; set; }
        public int deptid { get; set; }

        public Department tchdept { get; set; }
        public course tchcourse { get; set; }
    }
}
