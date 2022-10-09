using System;
using OrdersSample.Controllers;
using OrdersSample.Interfaces;
using OrdersSample.Models;

namespace OrdersSample.Services
{
	public class OrderService : IOrderService
	{
        private readonly ILogger<OrderController> _logger;
        private readonly IDatabaseService _service;

        public OrderService(ILogger<OrderController> logger, IDatabaseService service)
		{
            _logger = logger;
            _service = service;
		}

        public Order GetById(string id)
        {
            return _service.GetData<Order>(id);
        }

        public Guid Send(Order order)
        {
            _service.SetData<Order>(order.id.ToString(), order);
            return order.id;
        }
    }
}

