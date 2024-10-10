using AutoMapper;
using FastFood.Contract.Repositories.Entity;
using FastFood.Contract.Repositories.Interface;
using FastFood.Contract.Services.Interface;
using FastFood.Core.Base;
using FastFood.ModelViews.PositionViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static FastFood.Core.Base.BaseException;

namespace FastFood.Services.Service
{
    public class PositionService : IPositionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PositionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // Get ID
        public async Task<GetPositionViewModel?> GetByIdAsync(string id)
        {
            Position? position = await _unitOfWork.GetRepository<Position>().Entities.FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue) ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Position does not exist");
            return _mapper.Map<Position, GetPositionViewModel>(position);
        }

        // Get All
        public async Task<IEnumerable<GetPositionViewModel>> GetAllAsync()
        {
            var allPositions = _unitOfWork.GetRepository<Position>().Entities.Where(p => !p.DeletedTime.HasValue);
            return await _mapper.ProjectTo<GetPositionViewModel>(allPositions).ToListAsync();
        }

        // Get Page
        public async Task<IEnumerable<GetPositionViewModel>> GetPagedAsync(int pageIndex, int pageSize)
        {
            var allPositions = _unitOfWork.GetRepository<Position>().Entities.Where(p => !p.DeletedTime.HasValue);
            var items = await _mapper.ProjectTo<GetPositionViewModel>(allPositions).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return items;
        }

        // Create
        public async Task<string> AddAsync(CreatePositionViewModel positionViewModel)
        {
            var existingPosition = await _unitOfWork.GetRepository<Position>().Entities.FirstOrDefaultAsync(p => p.Role == positionViewModel.Role);
            if (existingPosition != null)
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "Position with this role already exists.");
            }
            Position role = _mapper.Map<Position>(positionViewModel);
            await _unitOfWork.GetRepository<Position>().InsertAsync(role);
            await _unitOfWork.SaveAsync();
            return role.Id;
        }

        // Update
        public async Task UpdateAsync(string id, UpdatePositionViewModel positionViewModel)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "ID cannot be blank.");
            }
            Position? position = await _unitOfWork.GetRepository<Position>().Entities.FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue) ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Position does not exist");
            _mapper.Map(positionViewModel, position);
            await _unitOfWork.GetRepository<Position>().UpdateAsync(position);
            await _unitOfWork.SaveAsync();
        }

        // Detele
        public async Task DeleteAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ErrorException(StatusCodes.Status400BadRequest, ResponseCodeConstants.INVALID_INPUT, "ID cannot be blank.");
            }
            Position? position = await _unitOfWork.GetRepository<Position>().Entities.FirstOrDefaultAsync(p => p.Id == id && !p.DeletedTime.HasValue) ?? throw new ErrorException(StatusCodes.Status404NotFound, ResponseCodeConstants.NOT_FOUND, "Position does not exist");
            position.DeletedTime = DateTime.Now;
            await _unitOfWork.GetRepository<Position>().UpdateAsync(position);
            await _unitOfWork.SaveAsync();
        }

        // Soft Delete
        public IQueryable<Position> GetActivePositions()
        {
            return _unitOfWork.GetRepository<Position>().Entities.Where(p => !p.DeletedTime.HasValue);
        }

        public async Task AddDefaultRolesAsync()
        {
            var defaultRoles = new List<string> { "System Admin", "Customer", "Court Manager", "Court Staff" };
            var existingRoles = await _unitOfWork.GetRepository<Position>().Entities.Where(p => !p.DeletedTime.HasValue&& defaultRoles.Contains(p.Role)).Select(p => p.Role).ToListAsync();
            var rolesToAdd = defaultRoles.Except(existingRoles).ToList();
            if (rolesToAdd.Any())
            {
                foreach (var role in rolesToAdd)
                {
                    Position newPosition = new Position { Role = role };
                    await _unitOfWork.GetRepository<Position>().InsertAsync(newPosition);
                }
                await _unitOfWork.SaveAsync();
            }
        }
    }
}
