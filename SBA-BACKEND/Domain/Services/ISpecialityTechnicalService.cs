using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface ISpecialityTechnicalService
	{
		Task<SpecialityTechnicalResponse> GetByIdAsync(int id);
		Task<SpecialityTechnicalResponse> SaveAsync(SpecialityTechnical specialitytechnical);
		Task<SpecialityTechnicalResponse> UpdateAsync(int id, SpecialityTechnical specialitytechnical);
		Task<SpecialityTechnicalResponse> DeleteAsync(int id);

	}
}
