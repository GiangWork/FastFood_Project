using FastFood.ModelViews.PositionViewModel;

namespace FastFood.Contract.Services.Interface
{
    public interface IPositionService
    {
        // Retrieves a position by its unique identifier.
        Task<GetPositionViewModel?> GetByIdAsync(string id);

        // Retrieves all positions.
        Task<IEnumerable<GetPositionViewModel>> GetAllAsync();

        // Retrieves a paginated list of positions.
        Task<IEnumerable<GetPositionViewModel>> GetPagedAsync(int pageIndex, int pageSize);

        // Add
        Task<string> AddAsync(CreatePositionViewModel positionViewModel);

        // Update
        Task UpdateAsync(string id, UpdatePositionViewModel positionViewModel);

        // Delete
        Task DeleteAsync(string id);

        Task AddDefaultRolesAsync();
    }
}
