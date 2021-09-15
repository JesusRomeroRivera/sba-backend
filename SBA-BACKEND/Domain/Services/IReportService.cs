using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface IReportService
	{
		Task<ReportResponse> GetByIdAsync(int id);
		Task<ReportResponse> SaveAsync(Report report);
		Task<ReportResponse> UpdateAsync(int id, Report report);
		Task<ReportResponse> DeleteAsync(int id);

	}
}
