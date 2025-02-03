using myappAPI.Models;

namespace myappAPI.DAL
{
    public interface IUser : ICrud<User>
    {
        //IEnumerable<User> GetUsers();
    }
}