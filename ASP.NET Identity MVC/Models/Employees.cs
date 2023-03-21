namespace ASP.NET_Identity_MVC.Models
{
    public class Employees
    {
        public int Id { get; set; }
        public string ?Name { get; set; }
        public string? Email { get; set; }
        public string ? Address { get; set; }

        public Deprt? Department { get; set; } 
    }
}
