using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{
	public interface ISpecialityTechnicianRepository
	{
		Task AddAsync(SpecialityTechnician specialityTechnician);
		Task<SpecialityTechnician> FindById(int specialityId, int technicianId);
		Task<IEnumerable<SpecialityTechnician>> ListAsync();
		void Remove(SpecialityTechnician specialityTechnician);
		void Update(SpecialityTechnician specialityTechnician);
	}
}
