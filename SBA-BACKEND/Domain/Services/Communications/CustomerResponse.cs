using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class CustomerResponse : BaseResponse<Customer>
	{
		public CustomerResponse(Customer resource) : base(resource)
		{
		}

		public CustomerResponse(string message) : base(message)
		{
		}
	}
}
