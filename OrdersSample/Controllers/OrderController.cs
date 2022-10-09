using System;
using Microsoft.AspNetCore.Mvc;
using OrdersSample.Interfaces;
using OrdersSample.Models;
using OrdersSample.Services;

namespace OrdersSample.Controllers
{
    [ApiController]
    [Route("/")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderController(ILogger<OrderController> logger,IOrderService orderService, IProductService productService)
        {
            _logger = logger;
            _orderService = orderService;
            _productService = productService;
        }

        [HttpGet("Products")]
        public List<Product> GetProducts()
        {
            return _productService.Get();
        }

        [HttpGet("ProductById")]
        public Product GetProductById(string id)
        {
            return _productService.GetById(id);
        }

        [HttpPost("AddOrder")]
        public Guid AddOrder(NewOrder newOrder)
        {
            var product = _productService.GetById(newOrder.product_id);

            Order order = new Order()
            {
                client_id = newOrder.client_id,
                product_id = newOrder.product_id,
                product_name = product.name,
                price = product.price
            };

            return _orderService.Send(order);
        }

        [HttpPost("GetOrderById")]
        public Order GetOrderById(string id)
        {
            return _orderService.GetById(id);
        }
    }
}

