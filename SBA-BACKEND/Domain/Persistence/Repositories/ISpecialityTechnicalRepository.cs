using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	interface ISpecialityTechnicalRepository
	{
		Task AddAsync(SpecialityTechnical specialityTechnical);
		Task<SpecialityTechnical> FindById(int specialityId, int technicalId);
		Task<IEnumerable<SpecialityTechnical>> ListAsync();
		void Remove(SpecialityTechnical specialityTechnical);
		void Update(SpecialityTechnical specialityTechnical);
	}
}
