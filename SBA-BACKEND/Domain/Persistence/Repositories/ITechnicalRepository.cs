using SBA_BACKEND.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_BACKEND.Domain.Persistence.Repositories
{	interface ITechnicalRepository
	{
		Task<IEnumerable<Technical>> ListAsync();
		Task AddAsync(Technical technical);
		Task<Technical> FindById(int id);
		void Update(Technical technical);
		void Remove(Technical technical);
	}
}
