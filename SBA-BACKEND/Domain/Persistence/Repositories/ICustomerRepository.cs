using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	interface ICustomerRepository
	{
		Task<IEnumerable<Customer>> ListAsync();
		Task AddAsync(Customer customer);
		Task<Customer> FindById(int id);
		void Update(Customer customer);
		void Remove(Customer customer);
	}
}
