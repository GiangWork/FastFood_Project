using FastFood.Core;
using FastFood.ModelViews.UserModelViews;

namespace FastFood.Contract.Services.Interface
{
    public interface IUserService
    {

        Task<BasePaginatedList<UserViewModel>> GetAll(int pageNumber, int pageSize);
        Task<UserViewModel> GetById(string id);
        Task Update(string id, UserUpdateModel request);
        Task Delete(string id);

        Task ResetPassword(string id);  // Reset

        Task ChangePassword(ChangePasswordModelView req);
        Task ChangeRole(string id, ChangeRoleModel request);

        Task AddAdminAccount();
    }
}
