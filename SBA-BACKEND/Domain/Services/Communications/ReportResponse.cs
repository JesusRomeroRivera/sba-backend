using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;

namespace SBA_BACKEND.Domain.Services.Communications
{
	public class ReportResponse : BaseResponse<Report>
	{
		public ReportResponse(Report resource) : base(resource)
		{
		}

		public ReportResponse(string message) : base(message)
		{
		}
	}
}
