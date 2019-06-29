﻿namespace eOrder.CORE.Requests
{
    public class OrderDetailsSearchRequest
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public OrderDTO Order { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public double ProductPrice { get; set; }
    }
}