using AkademiPlusMicroserviceProje.Catalog.Dtos;
using AkademiPlusMicroserviceProje.Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.Catalog.Services.Abstract
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<ProductDto>> CreateAsync(CreateProductDto createProductDto);

        Task<Response<ProductDto>> GetByIDAsync(string id);
        Task<Response<NoContent>> UpdateAsync(UpdateProductDto updateProductDto);

        Task<Response<NoContent>> DeleteAsync(string id);
    }
}
