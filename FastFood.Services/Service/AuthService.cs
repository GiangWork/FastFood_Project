using AutoMapper;
using FastFood.Contract.Repositories.Entity;
using FastFood.Contract.Repositories.Interface;
using FastFood.Contract.Services.Interface;
using FastFood.Core.Base;
using FastFood.ModelViews.AuthModelViews;
using FastFood.ModelViews.UserModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static FastFood.Core.Base.BaseException;

namespace FastFood.Services.Service
{
    public class AuthService : IAuthService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task Register(UserCreateModel request)
        {
            //Kiểm tra có trùng username hay không
            UserInfo? checkUserName = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Username == request.Username && !u.DeletedTime.HasValue).FirstOrDefaultAsync();
            if (checkUserName != null)
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "UserName đã tồn tại !");

            //Kiểm tra số điện thoại không chứa ký tự và không được có hơn 10 số
            if (!request.PhoneNumber.All(char.IsDigit) || request.PhoneNumber.Length > 10)
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "PhoneNumber không hợp lệ !");
            }

            //Kiểm tra số điện thoại có trùng hay không
            UserInfo? checkPhoneNumber = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.PhoneNumber == request.PhoneNumber && !u.DeletedTime.HasValue).FirstOrDefaultAsync();
            if (checkPhoneNumber != null)
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "PhoneNumber đã tồn tại !");


            Position? role = await _unitOfWork.GetRepository<Position>().Entities.Where(p => p.Role == "Customer" && !p.DeletedTime.HasValue).FirstOrDefaultAsync()
             ?? throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "Không tìm thấy Position Customer !");

            UserInfo user = _mapper.Map<UserInfo>(request);
            user.PositionId = role.Id;
            await _unitOfWork.GetRepository<UserInfo>().InsertAsync(user);
            await _unitOfWork.SaveAsync();

        }

        public async Task<string> Login(LoginModelView request)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Username == request.Username && u.Password == request.Password && !u.DeletedTime.HasValue).FirstOrDefaultAsync();
            if (user == null || user.Status == UserInfo.UserStatus.Inactive.ToString())
            {
                return "Login thất bại !";
            }
            return _tokenService.CreateToken(user);

        }
    }
}
