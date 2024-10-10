using FastFood.Contract.Services.Interface;
using FastFood.Core.Base;
using FastFood.Core.Constants;
using FastFood.ModelViews.AuthModelViews;
using FastFood.ModelViews.UserModelViews;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        /// <summary>
        /// Authorize: All
        /// </summary>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelView request)
        {
            string token = await _authService.Login(request);
            return Ok(new BaseResponse<string>(
               statusCode: StatusCodeHelper.OK,
               code: ResponseCodeConstants.SUCCESS,
               data: token));

        }
        /// <summary>
        /// Authorize: All
        /// </summary>
        [HttpPost("Register_Customer_Account")]
        public async Task<IActionResult> Register([FromBody] UserCreateModel request)
        {
            await _authService.Register(request);
            return Ok(new BaseResponse<string>(
               statusCode: StatusCodeHelper.OK,
               code: ResponseCodeConstants.SUCCESS,
               data: "Tạo Tài Khoản mới thành công!"));
        }
    }
}
