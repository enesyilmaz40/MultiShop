using MultiShop.Basket.Dtos;
using MultiShop.Basket.Settings;
using Newtonsoft.Json;
using System.Text.Json;

namespace MultiShop.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string userId)
        {
            await _redisService.GetDb().KeyDeleteAsync(userId);
        }

        public async Task<BasketTotalDto> GetBasket(string userId)
        {
            try
            {
                var existBasket = await _redisService.GetDb().StringGetAsync(userId);
                if (!existBasket.HasValue)
                    return null;

                // Veriyi deserialize et
                var value = JsonConvert.DeserializeObject<BasketTotalDto>(existBasket);
                return value;
            }
            catch (Exception ex)
            {
                // Hata yönetimi
                throw new Exception("Error during basket retrieval", ex);
            }
        }
        public async Task SaveBasket(BasketTotalDto basketTotalDto)
        {
            await _redisService.GetDb().StringSetAsync(basketTotalDto.UserId, JsonConvert.SerializeObject(basketTotalDto));
        }
    }
}
