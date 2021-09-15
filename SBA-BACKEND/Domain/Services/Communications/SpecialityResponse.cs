using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class SpecialityResponse : BaseResponse<Speciality>
	{
		public SpecialityResponse(Speciality resource) : base(resource)
		{
		}

		public SpecialityResponse(string message) : base(message)
		{
		}
	}
}
