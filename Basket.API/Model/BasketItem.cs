﻿namespace Basket.API.Model
{
    public class BasketItem
    {
        public string Id { get; set; } = null!;
        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public decimal TotalUnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = null!;
    }
}
