using System;
using OrdersSample.Models;

namespace OrdersSample.Interfaces
{
	public interface IOrderService
	{
        public Guid Send(Order order);

        public Order GetById(string id);
    }
}

