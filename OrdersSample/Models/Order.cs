using System;
namespace OrdersSample.Models
{
	public class Order
	{
        public Guid id { get; } = Guid.NewGuid();

        public DateTime date { get; } = DateTime.Now;

        public string client_id { get; set; }

        public string product_id { get; set; }

        public string product_name { get; set; }

        public decimal price { get; set; }
    }
}

