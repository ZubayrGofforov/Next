using Next.Web.Models;

namespace Next.Web.Interfaces;
public interface IUserService
{
    public IEnumerable<User> GetAllUser();
    public User GetById(Guid id);
    public void AddUser(User user);
    public void DeleteUser(User user);
    public void UpdateUser(User user);
}
