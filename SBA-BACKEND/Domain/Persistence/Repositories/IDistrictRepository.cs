using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	public interface IDistrictRepository
	{
		Task<IEnumerable<District>> ListAsync();
		Task AddAsync(District district);
		Task<District> FindById(int id);
		void Update(District district);
		void Remove(District district);
	}
}
