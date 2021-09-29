using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace SBA_BACKEND.Domain.Services
{
	public interface ISpecialityTechnicianService
	{
		Task<SpecialityTechnicianResponse> GetByIdAsync(int id);
		Task<SpecialityTechnicianResponse> SaveAsync(SpecialityTechnician specialitytechnician);
		Task<SpecialityTechnicianResponse> UpdateAsync(int id, SpecialityTechnician specialitytechnician);
		Task<SpecialityTechnicianResponse> DeleteAsync(int id);

	}
}
