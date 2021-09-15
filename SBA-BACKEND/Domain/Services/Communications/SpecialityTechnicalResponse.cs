using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class SpecialityTechnicalResponse : BaseResponse<SpecialityTechnical>
	{
		public SpecialityTechnicalResponse(SpecialityTechnical resource) : base(resource)
		{
		}

		public SpecialityTechnicalResponse(string message) : base(message)
		{
		}
	}
}
