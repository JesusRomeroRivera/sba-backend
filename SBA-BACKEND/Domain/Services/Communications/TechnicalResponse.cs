using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class TechnicalResponse : BaseResponse<Technical>
	{
		public TechnicalResponse(Technical resource) : base(resource)
		{
		}

		public TechnicalResponse(string message) : base(message)
		{
		}
	}
}
