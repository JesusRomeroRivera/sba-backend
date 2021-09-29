using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SBA_BACKEND.Domain.Models;
using SBA_BACKEND.Domain.Services.Communications;

namespace SBA_BACKEND.Domain.Services
{
	public interface ITechnicianService
	{
		Task<TechnicianResponse> GetByIdAsync(int id);
		Task<TechnicianResponse> SaveAsync(Technician technician);
		Task<TechnicianResponse> UpdateAsync(int id, Technician technician);
		Task<TechnicianResponse> DeleteAsync(int id);

	}
}
