using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class TechnicianResponse : BaseResponse<Technician>
	{
		public TechnicianResponse(Technician resource) : base(resource)
		{
		}

		public TechnicianResponse(string message) : base(message)
		{
		}
	}
}
