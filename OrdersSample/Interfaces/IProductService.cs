using System;
using OrdersSample.Models;

namespace OrdersSample.Interfaces
{
	public interface IProductService
	{
		public List<Product> Get();

		public Product GetById(string id);
	}
}