using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace TPC_UPC.Domain.Services
{
	public interface ISpecialityService
	{
		Task<SpecialityResponse> GetByIdAsync(int id);
		Task<SpecialityResponse> SaveAsync(Speciality speciality);
		Task<SpecialityResponse> UpdateAsync(int id, Speciality speciality);
		Task<SpecialityResponse> DeleteAsync(int id);

	}
}
