using System.Threading.Tasks;
using AkademiPlusMicroserviceProje.Basket.Dto;
using AkademiPlusMicroserviceProje.Shared.Dtos;

namespace AkademiPlusMicroserviceProje.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string UserID);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);
        Task<Response<bool>> Delete(string UserID);
    }
}
