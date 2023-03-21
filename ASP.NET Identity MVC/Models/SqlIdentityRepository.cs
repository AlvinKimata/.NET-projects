namespace ASP.NET_Identity_MVC.Models
{
    public class SqlIdentityRepository : IdentityRepository
    { 
        private readonly ProjectDbContext context;

        public SqlIdentityRepository(ProjectDbContext context) 
        {
            this.context = context;
        }

        public Employees Add(Employees employees)
        {
            context.Employees.Add(employees);
            context.SaveChanges();
            return employees;
        }

        public Employees Delete(int Id)
        {
        Employees employee = context.Employees.Find(Id);
        if (employee != null)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }
            return employee;
        }

        public IEnumerable<Employees> GetEmployees()
        {
            return context.Employees;
        }

        public Employees GetEmployees(int Id)
        {
            return context.Employees.Find(Id);
        }

        public Employees Update(Employees employeeChanges)
        {
            var employees = context.Employees.Attach(employeeChanges);
            employees.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

    }
}
