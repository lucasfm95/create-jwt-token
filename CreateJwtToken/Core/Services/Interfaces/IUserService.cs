using CreateJwtTokenApi.Domain.Model;

namespace CreateJwtTokenApi.Core.Services.Interfaces
{
    public interface IUserService
    {
        string GenerateToken(UserModel user);
        UserModel FindUser(UserModel userModel);
    }
}
