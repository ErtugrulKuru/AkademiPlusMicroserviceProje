using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Catalog.Models;
using AkademiPlusMicroserviceProje.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Abstract
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> CreateAsync(CreateCategoryDto createCategoryDto);

        Task<Response<CategoryDto>> GetByIDAsync(string id);
        Task<Response<NoContent>> UpdateAsync(UpdateCategoryDto updateCategoryDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
