﻿using Microsoft.AspNetCore.Mvc;
using Basket.API.Repositories;
using Basket.API.Extensions;
using Microsoft.AspNetCore.Authorization;
using MassTransit;
using AutoMapper;
using EventBus.Messaging.Events;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository basketRepository;

        private readonly IPublishEndpoint publishEndpoint;

        public BasketController(IBasketRepository basketRepository, IPublishEndpoint publishEndpoint)
        {
            this.basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));

            this.publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [AllowAnonymous]
        [HttpGet("get/{userId}")]
        public async Task<IActionResult> GetBasket([FromRoute] string userId)
        {
            if (userId == null ||  userId.Length == 0)
            {
                return Ok("No basket found");
            }
            var basket = await basketRepository.GetBasketAsync(userId);

            if (basket != null)
            {
                return Ok(basket);
            }
            return Ok("No basket found");
        }

        [HttpPost("update/{userId}")]
        public async Task<IActionResult> UpdateBasket([FromRoute] string userId, [FromBody] List<Model.BasketItem> basketItems)
        {
            var customerBasket = ModelMapper.MapToCustomerBasket(userId, basketItems);

            try
            {
                var basket = await basketRepository.UpdateBasketAsync(customerBasket);
                return Ok(new {
                    Message = "Basket updated successfully",
                    Basket = basket
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{userId}")]
        public async Task<IActionResult> DeleteBasket(string userId)
        {
            await basketRepository.DeleteBasketAsync(userId);
            return Ok("Basket deleted successfully");
        }

        [HttpPost("checkout/{userId}")]
        public async Task<IActionResult> Checkout([FromRoute] string userId)
        {
            var basket = await basketRepository.GetBasketAsync(userId);

            if (basket == null)
            {
                return BadRequest("Customer basket not found !");
            }

            var eventMessage = ModelMapper.MapToBasketCheckoutEvent(userId, basket.Items);

            await publishEndpoint.Publish(eventMessage);

            await basketRepository.DeleteBasketAsync(userId);

            return Accepted("Order is being created");
        }
    }
}
