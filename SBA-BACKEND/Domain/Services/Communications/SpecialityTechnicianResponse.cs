using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class SpecialityTechnicianResponse : BaseResponse<SpecialityTechnician>
	{
		public SpecialityTechnicianResponse(SpecialityTechnician resource) : base(resource)
		{
		}

		public SpecialityTechnicianResponse(string message) : base(message)
		{
		}
	}
}
