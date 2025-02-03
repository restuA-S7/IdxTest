using myappAPI.Models;

namespace myappAPI.DAL
{
    public class UsersEF : IUser
    {
        private readonly ApplicationDbContext _appDBContext;
        public UsersEF(ApplicationDbContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        public IEnumerable<User> GetAll()
        {
            var result = _appDBContext.Users.OrderBy(c => c.UserName).ToList();
            return result;
        }
    }
}