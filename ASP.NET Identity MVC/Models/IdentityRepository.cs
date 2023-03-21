namespace ASP.NET_Identity_MVC.Models
{
    public interface IdentityRepository
    {
        Employees GetEmployees(int Id);
        IEnumerable<Employees> GetEmployees();

        Employees Add(Employees employee);
        Employees Update(Employees employee);
        Employees Delete(int Id);
    }
}
