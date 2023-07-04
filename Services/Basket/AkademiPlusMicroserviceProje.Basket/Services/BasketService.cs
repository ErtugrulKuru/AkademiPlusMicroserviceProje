using System.Text.Json;
using System.Threading.Tasks;
using AkademiPlusMicroserviceProje.Basket.Dto;
using AkademiPlusMicroserviceProje.Shared.Dtos;

namespace AkademiPlusMicroserviceProje.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<Response<bool>> Delete(string UserID)
        {
            var status=await _redisService.GetDb().KeyDeleteAsync(UserID);
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Sepet Bulunamadı.", 404);
        }

        public async Task<Response<BasketDto>> GetBasket(string UserID)
        {
            var exisBasket=await _redisService.GetDb().StringGetAsync(UserID);
            if (string.IsNullOrEmpty(exisBasket))
            {
                return Response<BasketDto>.Fail("Sepet Bulunamadı.", 404);
            }
            else
            {
                return Response<BasketDto>.Success(200,JsonSerializer.Deserialize<BasketDto>(exisBasket));
            }
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status =await _redisService.GetDb().StringSetAsync(basketDto.UserID,JsonSerializer.Serialize(basketDto));
            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Bir Hata Oluştu!!!", 404);
        }
    }
}
