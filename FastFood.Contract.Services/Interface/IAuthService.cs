using FastFood.ModelViews.AuthModelViews;
using FastFood.ModelViews.UserModelViews;

namespace FastFood.Contract.Services.Interface
{
    public interface IAuthService
    {

        Task<string> Login(LoginModelView request);
        Task Register(UserCreateModel request);
    }
}
