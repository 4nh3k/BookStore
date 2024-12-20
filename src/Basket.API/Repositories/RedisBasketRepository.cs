﻿using Basket.API.Model;
using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Repositories
{
    public class RedisBasketRepository(
        ILogger<RedisBasketRepository> logger, IConnectionMultiplexer redis) : IBasketRepository
    {
        private readonly IDatabase _database = redis.GetDatabase();

        private static RedisKey BasketKeyPrefix = "/basket/"u8.ToArray();

        private static RedisKey GetBasketKey(string userId) => BasketKeyPrefix.Append(userId);

        public async Task<bool> DeleteBasketAsync(string id)
        {
            var deleteStatus = await _database.KeyDeleteAsync(GetBasketKey(id));

            if (deleteStatus) logger.LogInformation($"Basket with id {id} deleted");
            else logger.LogInformation($"Basket with id {id} failed to delete");
            
            return deleteStatus;
        }

        public async Task<CustomerBasket?> GetBasketAsync(string customerId)
        {
            using var data = await _database.StringGetLeaseAsync(GetBasketKey(customerId));

            if (data is null || data.Length == 0)
            {
                logger.LogInformation("Basket data is null or empty");
                return null;
            }

            logger.LogInformation($"Basket of user {customerId} successfully fetched");
            return JsonSerializer.Deserialize(data.Span, BasketSerializationContext.Default.CustomerBasket);
        }

        public async Task<List<CustomerBasket>> GetBasketsContainItemAsync(int itemId)
        {
            logger.LogInformation($"GetBasketsContainItemAsync for {itemId} started");
            var basketsContainingBook = new List<CustomerBasket>();

            var endpoints = redis.GetEndPoints();
            var server = redis.GetServer(endpoints[0]);
            var keys = server.Keys();

            logger.LogInformation($"Total keys fetched {keys.Count()}");
            // Assuming _database is your Redis database instance
            foreach (var key in keys)
            {
                var data = await _database.StringGetLeaseAsync(key);
                var basket = JsonSerializer.Deserialize(data.Span, BasketSerializationContext.Default.CustomerBasket);

                if (basket != null && basket.Items.Any(item => item.BookId == itemId))
                {
                    basketsContainingBook.Add(basket);
                }
            }

            logger.LogInformation($"GetBasketsContainItemAsync for {itemId} ended, total basket matched: {basketsContainingBook.Count}");
            return basketsContainingBook;
        }

        public async Task UpdateItemPriceForBasket(int itemId, double newPrice)
        {
            logger.LogInformation($"Update item price for {itemId}");
            var basketsToUpdate = await GetBasketsContainItemAsync(itemId);

            int totalBasketUpdated = 0;

            foreach (var basket in basketsToUpdate)
            {
                // Update the price of the specified book within the basket
                foreach (var item in basket.Items)
                {
                    logger.LogInformation($"{item.BookId}");
                    if (item.BookId == itemId)
                    {
                        totalBasketUpdated++;
                        item.UnitPrice = (decimal)newPrice;
                        item.TotalUnitPrice = (decimal)newPrice * item.Quantity;
                    }
                }

                // Serialize the updated basket and save it back to Redis
                var serializedBasket = JsonSerializer.Serialize(basket, BasketSerializationContext.Default.CustomerBasket);
                await _database.StringSetAsync(GetBasketKey(basket.BuyerId), serializedBasket);
            }

            logger.LogInformation($"Total basket updated: {totalBasketUpdated}");
        }

        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            logger.LogInformation($"Began update basket of buyer: {basket.BuyerId}");
            var json = JsonSerializer.SerializeToUtf8Bytes(basket, BasketSerializationContext.Default.CustomerBasket);

            var created = await _database.StringSetAsync(GetBasketKey(basket.BuyerId), json);

            if (!created)
            {
                logger.LogInformation("Problem occurred persisting the item.");
            }
            logger.LogInformation("Basket item persisted successfully");
            return await GetBasketAsync(basket.BuyerId);
        }
    }


    [JsonSerializable(typeof(CustomerBasket))]
    [JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
    public partial class BasketSerializationContext : JsonSerializerContext
    {

    }
}
