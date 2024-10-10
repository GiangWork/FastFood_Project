using AutoMapper;
using FastFood.Contract.Repositories.Entity;
using FastFood.Contract.Repositories.Interface;
using FastFood.Contract.Services.Interface;
using FastFood.Core;
using FastFood.Core.Base;
using FastFood.ModelViews.UserModelViews;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static FastFood.Core.Base.BaseException;

namespace FastFood.Services.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<BasePaginatedList<UserViewModel>> GetAll(int pageNumber, int pageSize)
        {
            var allUser = _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => !u.DeletedTime.HasValue);
            var totalItems = await allUser.CountAsync();
            var items = allUser.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var mappedItems = items.Select(user =>
            {
                var userViewModel = _mapper.Map<UserViewModel>(user);
                userViewModel.Role = user.Position?.Role;

                return userViewModel;
            }).ToList();

            var paginatedList = new BasePaginatedList<UserViewModel>(mappedItems, totalItems, pageNumber, pageSize);
            return paginatedList;
        }
        public async Task<UserViewModel> GetById(string id)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Id == id && !u.DeletedTime.HasValue).FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Không tìm thấy User");

            var userViewModel = _mapper.Map<UserViewModel>(user);
            userViewModel.Role = user.Position?.Role;


            return userViewModel;

        }
        public async Task Delete(string id)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Id == id && !u.DeletedTime.HasValue).FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Không tìm thấy User");

            user.DeletedTime = DateTime.Now;
            user.Status = UserInfo.UserStatus.Inactive.ToString();
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task Update(string id, UserUpdateModel request)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Id == id && !u.DeletedTime.HasValue).FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Không tìm thấy User");

            if (request.Username != "string")
            {
                user.Username = request.Username;
            }
            if (request.Gender != "string")
            {
                user.Gender = request.Gender;
            }
            if (request.PhoneNumber != "string")
            {
                if (!request.PhoneNumber.All(char.IsDigit) || request.PhoneNumber.Length > 10)
                {
                    throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "PhoneNumber không hợp lệ !");
                }
                UserInfo? checkPhoneNumber = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.PhoneNumber == request.PhoneNumber && !u.DeletedTime.HasValue).FirstOrDefaultAsync();
                if (checkPhoneNumber != null)
                    throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "PhoneNumber đã tồn tại !");
                user.PhoneNumber = request.PhoneNumber;
            }
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        // Reset
        public async Task ResetPassword(string id)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities
                .Where(u => u.Id == id && !u.DeletedTime.HasValue)
                .FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "User not found");
            user.Password = "1";
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task ChangePassword(ChangePasswordModelView req)
        {
            // Lấy thông tin người dùng hiện tại từ JWT token
            string? userId = _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? throw new ErrorException(StatusCodes.Status401Unauthorized, ResponseCodeConstants.UNAUTHORIZED, "Unauthorized");

            UserInfo? findUser = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => !u.DeletedTime.HasValue
            && u.Id == userId).FirstOrDefaultAsync() ?? throw new ErrorException(StatusCodes.Status404NotFound,
            ResponseCodeConstants.NOT_FOUND, "Không tìm được user");

            // Kiểm tra mật khẩu cũ
            if (findUser.Password != req.OldPassword)
            {
                throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Sai mật khẩu");
            }

            // Kiểm tra tính hợp lệ của mật khẩu mới và xác nhận
            if (req.NewPassword != req.ConfirmPassword)
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT,
                    "Password và confirm password phải giống nhau");
            }

            if (findUser.Password == req.NewPassword)
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT,
                    "Mật khẩu mới không được giống mật khẩu cũ");
            }

            // Thay đổi mật khẩu
            findUser.Password = req.NewPassword;
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(findUser);
            await _unitOfWork.SaveAsync();
        }

        public async Task AddAdminAccount()
        {
            var adminUserName = "Admin";
            var adminPassword = "123";

            // kiểm tra tồn tại tài khoản admin
            UserInfo? findUser = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => !u.DeletedTime.HasValue
            && u.Username == adminUserName && u.Password == adminPassword).FirstOrDefaultAsync();

            if (findUser == null)
            {
                Position findPosition = await _unitOfWork.GetRepository<Position>().Entities.Where(u => !u.DeletedTime.HasValue && u.Role == "System Admin").FirstOrDefaultAsync();

                UserCreateModel adminUser = new UserCreateModel
                {
                    Username = adminUserName,
                    Password = adminPassword,

                };
                UserInfo newUser = _mapper.Map<UserInfo>(adminUser);
                newUser.PositionId = findPosition.Id;
                await _unitOfWork.GetRepository<UserInfo>().InsertAsync(newUser);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task ChangeRole(string id, ChangeRoleModel request)
        {
            UserInfo? user = await _unitOfWork.GetRepository<UserInfo>().Entities.Where(u => u.Id == id && !u.DeletedTime.HasValue).FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Không tìm thấy User");

            Position? kiemTraRole = await _unitOfWork.GetRepository<Position>().Entities.Where(p => p.Id == request.PositionId && !p.DeletedTime.HasValue).FirstOrDefaultAsync()
                ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Không tìm thấy Role này");
            user.PositionId = request.PositionId;
            await _unitOfWork.GetRepository<UserInfo>().UpdateAsync(user);
            await _unitOfWork.SaveAsync();

        }
    }
}
