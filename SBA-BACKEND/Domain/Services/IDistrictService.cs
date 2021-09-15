using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface IDistrictService
	{
		Task<DistrictResponse> GetByIdAsync(int id);
		Task<DistrictResponse> SaveAsync(District district);
		Task<DistrictResponse> UpdateAsync(int id, District district);
		Task<DistrictResponse> DeleteAsync(int id);

	}
}
