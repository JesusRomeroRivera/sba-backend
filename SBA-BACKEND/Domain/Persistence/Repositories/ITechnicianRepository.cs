using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{
	public interface ITechnicianRepository
	{
		Task<IEnumerable<Technician>> ListAsync();
		Task AddAsync(Technician technician);
		Task<Technician> FindById(int id);
		void Update(Technician technician);
		void Remove(Technician technician);
	}
}
