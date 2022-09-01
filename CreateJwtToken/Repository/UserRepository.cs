using CreateJwtTokenApi.Domain.Model;
using CreateJwtTokenApi.Repository.Interfaces;

namespace CreateJwtTokenApi.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserModel Get(string username, string password)
        {
            var users = new List<UserModel>();
            users.Add(new UserModel { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new UserModel { Id = 2, Username = "robin", Password = "robin", Role = "employee" });
            return users.FirstOrDefault(x => 
                string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase) && 
                string.Equals(x.Password, password, StringComparison.CurrentCultureIgnoreCase)
            );
        }
    }
}
