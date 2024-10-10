using FastFood.Contract.Services.Interface;
using FastFood.Core;
using FastFood.Core.Base;
using FastFood.Core.Constants;
using FastFood.ModelViews.UserModelViews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        /// Authorize: System Admin
        /// </summary>
        [HttpGet]
        [Authorize(Roles = "System Admin")]
        public async Task<IActionResult> GetAll(int pageNumber, int pageSize)
        {
            var result = await _userService.GetAll(pageNumber, pageSize);
            return Ok(new BaseResponse<BasePaginatedList<UserViewModel>>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: result));
        }
        /// <summary>
        /// Authorize: System Admin", "Customer", "Court Manager", "Court Staff
        /// </summary>
        [HttpGet("{id}")]
        [Authorize(Roles = "System Admin, Customer, Court Manager, Court Staff")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _userService.GetById(id);

            return Ok(new BaseResponse<UserViewModel>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: result));
        }
        /// <summary>
        /// Authorize: System Admin", "Customer", "Court Manager", "Court Staff
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "System Admin, Customer, Court Manager, Court Staff")]
        public async Task<IActionResult> Update(string id, [FromBody] UserUpdateModel request)
        {

            await _userService.Update(id, request);
            return Ok(new BaseResponse<string>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: "Cập nhật User thành công!"));
        }
        /// <summary>
        /// Authorize: System Admin
        /// </summary>
        [HttpPut("{id}/ChangeRole")]
        [Authorize(Roles = "System Admin")]
        public async Task<IActionResult> ChangeRole(string id, [FromBody] ChangeRoleModel request)
        {

            await _userService.ChangeRole(id, request);
            return Ok(new BaseResponse<string>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: "Cập nhật Role thành công!"));
        }
        /// <summary>
        /// Authorize: System Admin
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "System Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return Ok(new BaseResponse<string>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: "Xóa User thành công!"));
        }


        /// <summary>
        /// Authorize: System Admin
        /// </summary>
        [HttpPost("reset-password")]
        [Authorize(Roles = "System Admin")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            await _userService.ResetPassword(id);
            return Ok(new BaseResponse<string>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: "Password reset successful! The new password is '1'"));
        }
        /// <summary>
        /// Authorize: System Admin", "Customer", "Court Manager", "Court Staff
        /// </summary>
        [HttpPut("Change Password")]
        [Authorize(Roles = "System Admin, Customer, Court Manager, Court Staff")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModelView req)
        {
            await _userService.ChangePassword(req);
            return Ok(new BaseResponse<string>(
                statusCode: StatusCodeHelper.OK,
                code: ResponseCodeConstants.SUCCESS,
                data: "Đổi mật khẩu thành công"));
        }
    }
}
