using Mongo.Dtos.CategoryDto;

namespace Mongo.Service.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string deleteCategoryId);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(string getCategoryByIdId);
    }
}
