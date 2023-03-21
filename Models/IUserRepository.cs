namespace User_management.Models
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetAllUsers();
        User Add(User user);
    }
}
