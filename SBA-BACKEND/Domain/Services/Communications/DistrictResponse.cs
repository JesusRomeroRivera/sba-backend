using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class DistrictResponse : BaseResponse<District>
	{
		public DistrictResponse(District resource) : base(resource)
		{
		}

		public DistrictResponse(string message) : base(message)
		{
		}
	}
}
