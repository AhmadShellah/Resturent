﻿namespace BusinessObjects.Models
{
    public class OrderMealModel
    {
        public Guid MealId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}