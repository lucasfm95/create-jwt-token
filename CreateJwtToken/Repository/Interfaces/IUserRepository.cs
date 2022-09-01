using CreateJwtTokenApi.Domain.Model;

namespace CreateJwtTokenApi.Repository.Interfaces
{
    public interface IUserRepository
    {
        UserModel Get(string username, string password);
    }
}
