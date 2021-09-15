using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface ICustomerService
	{
		Task<CustomerResponse> GetByIdAsync(int id);
		Task<CustomerResponse> SaveAsync(Customer customer);
		Task<CustomerResponse> UpdateAsync(int id, Customer customer);
		Task<CustomerResponse> DeleteAsync(int id);

	}
}
