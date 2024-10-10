using FastFood.Contract.Repositories.Entity;

namespace FastFood.Contract.Services.Interface;
public interface ITokenService
{
    string CreateToken(UserInfo userInfo);
}
